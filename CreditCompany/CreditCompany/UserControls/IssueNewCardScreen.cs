using CreditCompanyEF;
using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
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
    public partial class IssueNewCardScreen : UserControl
    {
        private ManagerAgent managerAgent;
        private EventedObject<RequestsFromClient> respondRequest = new EventedObject<RequestsFromClient>();
        private Client client;
        private CreditCompanyEF.Models.CreditCard newCard = new CreditCompanyEF.Models.CreditCard() { Club = "הכללי", Credit = 1500 };
        
        private bool isNewClient = false;
        private CreditCard answer = null;


        public IssueNewCardScreen(ManagerAgent agent,Client client)
        {
            InitializeComponent();
            this.managerAgent = agent;
            this.client = client;
            ClientsNameLabel.Text = client.FirstName + " " + client.LastName;
            ClientIdLabel.Text = "מספר לקוח: " + client.ClientId;

            foreach (var acc in client.ClientsAccounts)
            {
                accountsCB.Items.Add((AccountDisplay)acc.Account);
                managerAgent.Detach(acc);
                managerAgent.Detach(acc.Account);
            }
            accountsCB.SelectedIndex = 0;


            newCard.Account = ((AccountDisplay)accountsCB.SelectedItem).account;

            //this.newCard = agent.AddCreditCard(1500, ((AccountDisplay)accountsCB.SelectedItem).account, "הכללי");

            //cardNumberTB.Text = newCard.CreditCardNumber;

            respondRequest.ValueChanged += (sender, e) => { 
                respondRequestLabel.Text=GetRequestText(respondRequest.Value);
            };
        }
        internal IssueNewCardScreen(ManagerAgent agent,Account account)
        {
            InitializeComponent();
            isNewClient = true;
            newCard.Account = account;
            this.managerAgent = agent;
            ClientsNameLabel.Text = "לקוח חדש";
            ClientIdLabel.Text = "מספר לקוח: ";
            accountsCB.Items.Clear();
            accountsCB.Items.Add(accountsCB);
            accountsCB.SelectedIndex = 0;
            chooseRespondeBtn.Visible = false;
            chooseRespondeBtn.Enabled = false;
            label5.Visible = false;
        }
        private string GetRequestText(RequestsFromClient request)
        {
            return $"מספר לקוח: {request.ClientId}{Environment.NewLine}" +
                            $"{request.Title}{Environment.NewLine}" +
                            $"{request.Content}";
        }

        private void chooseRespondeBtn_Click(object sender, EventArgs e)
        {
            var temp = RequestFromClientPicker.Pick(this, managerAgent.GetRequestsFromClients());
            if (temp is null)
                throw new NullReferenceException(nameof(temp) + "is null!");
            respondRequest.Set(temp);
        }

        private void IssueNewCardScreen_Load(object sender, EventArgs e)
        {

        }

        private void clubNameTB_TextChanged(object sender, EventArgs e)
        {
            //newCard.Club = cardNumberTB.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            newCard.Credit = (double?)cardCreditInput.Value;
        }

        private void issueBtn_Click(object sender, EventArgs e)
        {
            if(isNewClient)
            {
                NewClientAddition();
                return;
            }
            newCard=managerAgent.AddCreditCard(newCard.Credit is null?100:(double)newCard.Credit, newCard.Account, newCard.Club, true);
            managerAgent.AttachClient(newCard, client);
            if(respondRequest.Value is not null)
            {
                managerAgent.MarkAsAnswered(respondRequest.Value);
            }
            managerAgent.SaveChanges();
            MessageBox.Show(this, $"Card issued succefully with club {newCard.Club}", "yay",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void NewClientAddition()
        {
            answer = managerAgent.AddCreditCard(newCard.Credit is null ? 100 : (double)newCard.Credit, newCard.Account, newCard.Club, false);
            var p = this.Parent as Form;
            if (p is not null)
                p.Close();
        }

        internal static CreditCard GetNewCard(ManagerAgent agent, Account account)
        {
            var screen = new IssueNewCardScreen(agent, account);
            Form f = new Form();
            f.AutoSize = true;
            f.Controls.Add(screen);
            f.ShowDialog();
            return screen.answer;
        }
    }
    class AccountDisplay
    {
        internal Account account;


        public override string ToString()
        {
            return $"Bank: {account.BranchNumberNavigation.BankNumber}, Branch: {account.BranchNumber},  Account: {account.AccountNumber}";
        }

        public static explicit operator AccountDisplay(Account account)
        {
            return new AccountDisplay() { account = account };
        }
    }
}
