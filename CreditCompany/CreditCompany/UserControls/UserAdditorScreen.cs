using CreditCompany.UserControls.Extensions;
using CreditCompanyEF;
using CreditCompanyEF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCompany.UserControls
{
    public partial class UserAdditorScreen : UserControl
    {
        private ManagerAgent agent;
        private IEnumerable<Banks> banks= Banks.Yahav.BanksEnumerable();
        private List<Branch> branches = new List<Branch>();
        private Banks? SelectedBank => (bankCB.SelectedItem as Displayer<Banks>)?.Item;
        private Branch SelectedBranch => (branchCB.SelectedItem as Displayer<Branch>)?.Item;

        public UserAdditorScreen(ManagerAgent agent)
        {
            InitializeComponent();
            this.agent = agent;
            foreach (var bank in banks)
                branches.AddRange(agent.GetAllBranchesModels(bank));
            FurtherInitialize();
            bankCB.SelectedIndexChanged += RestrictBranchCB;
            branchCB.SelectedIndexChanged += (sender,e)=> {
                int index = IndexOfBank((Banks)SelectedBranch.BankNumber);
                if (index > -1)
                    bankCB.SelectedItem = bankCB.Items[index];
            };
        }
        private int IndexOfBank(Banks bank)
        {
            for (int i = 0; i < bankCB.Items.Count; i++)
            {
                if (((Displayer<Banks>)bankCB.Items[i]).Item == bank)
                    return i;
            }
            return -1;
        }
        private void RestrictBranchCB(object sender, EventArgs e)
        {
            ResetBranchCB();
            List<object> removers = new List<object>();
            for (int i = 0; i < branchCB.Items.Count; i++)
            {
                if (((Displayer<Branch>)branchCB.Items[i]).Item.BankNumber != (int)SelectedBank)
                    removers.Add(branchCB.Items[i]);
            }
            foreach (var item in removers)
            {
                branchCB.Items.Remove(item);
            }
        }

        private void CBsReset()
        {
            ResetBankCB();
            ResetBranchCB();
           
        }

        private void ResetBranchCB()
        {
            branchCB.Items.Clear();
            branchCB.Items.AddRange(branches.ToDisplayerList((br) => {
                return $"{br.BranchNumber}, {br.BranchName}";
            }).ToArray());
        }

        private void ResetBankCB()
        {
            bankCB.Items.Clear();
            bankCB.Items.AddRange(banks.ToDisplayerList((b) => {
                return $"{(int)b}, {b.ToString()}";
            }).ToArray());
        }

        private void FurtherInitialize()
        {
            userNameTB.Text = "";
            passwordTB.Text = "";
            firstNameTB.Text = "";
            lastNameTB.Text = "";
            bankCB.Text = "";
            branchCB.Text = "";
            accountNUD.Value = 0;
            creditScoreNUD.Value = 0;
            startDateDTP.Value = DateTime.Now;
            startDateDTP.MaxDate = DateTime.Now;
            startDateDTP.MinDate = new DateTime(1900, 1, 1);
            isManagerRB.Checked = false;
            isClientRB.Checked = false;
            CBsReset();
        }

        private void UserAdditorScreen_Load(object sender, EventArgs e)
        {

        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            bool result=ValidteValues();
            if (result == false)
                return;
            var user=agent.AddUser(userNameTB.Text, passwordTB.Text);
            if (isManagerRB.Checked)
            {
                Manager manager = new Manager();
                manager.ManagerName = firstNameTB.Text + " " + lastNameTB.Text;
                agent.AddManager(user, manager);
            }
            if (isClientRB.Checked)
            {
                var account = agent.GenerateAccount((int)accountNUD.Value, SelectedBranch.BranchNumber);
                var card = IssueNewCardScreen.GetNewCard(agent, account);
                var client=await agent.AddClientAsync(((int)creditScoreNUD.Value), firstNameTB.Text, lastNameTB.Text,new CreditCard[] {card}, user);
                user.IfClient = client;
                agent.AddMesasge("Thanks for joining", "Thank you for joining us", client);
                agent.AddMesasge("First Card issued!", $"Card's club: {card.Club}, Card's Credit: {card.Credit}", client);
            }
            agent.SaveChanges();
            MessageBox.Show(this, "The client has been added.", "The client has been added succefully!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidteValues()
        {
            var r = true;
            if (agent.IsUserNameExists(userNameTB.Text))
            {
                r = false;
                takenUserNameLabel.Visible = true;
            }
            if(passwordTB.Text.Length>20||passwordTB.Text.Length<6)
            {
                r = false;
                incorrectPasswordLabel.Visible = true;
            }
            if(creditScoreNUD.Value<100||creditScoreNUD.Value>1000)
            {
                r = false;
                creditScoreInvalidLabel.Visible = true;
            }
            if(SelectedBank is null)
            {
                r = false;
                chooseBankLabel.Visible = true;
            }
            if(SelectedBranch is null)
            {
                r = false;
                chooseBranchLabel.Visible = true;
            }
            if(accountNUD.Value<1||accountNUD.Value>999999999)
            {
                r = false;
                accountInvalidLabel.Visible = true;
            }
            if (isClientRB.Checked == false && isManagerRB.Checked == false)
            {
                r = false;
                identityNullLabel.Visible = true;
            }
            return r;
        }

        private void userNameTB_TextChanged(object sender, EventArgs e)
        {
            takenUserNameLabel.Visible = false;
        }

        private void passwordTB_TextChanged(object sender, EventArgs e)
        {
            incorrectPasswordLabel.Visible = false;
        }

        private void creditScoreNUD_ValueChanged(object sender, EventArgs e)
        {
            creditScoreInvalidLabel.Visible = false;
        }

        private void bankCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            chooseBankLabel.Visible = false;
        }

        private void branchCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            chooseBranchLabel.Visible = false;
        }

        private void accountNUD_ValueChanged(object sender, EventArgs e)
        {
            accountInvalidLabel.Visible = false;
        }

        private void isManagerRB_CheckedChanged(object sender, EventArgs e)
        {
            identityNullLabel.Visible = false;
        }

        private void isClientRB_CheckedChanged(object sender, EventArgs e)
        {
            identityNullLabel.Visible = false;
        }

        private void isClientRB_CheckedChanged_1(object sender, EventArgs e)
        {
            identityNullLabel.Visible = false;
        }

        private void isManagerRB_CheckedChanged_1(object sender, EventArgs e)
        {
            identityNullLabel.Visible = false;
        }
    }
}
