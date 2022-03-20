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
    public partial class TransactionWritingScreen : UserControl
    {
        private ManagerAgent agent;
        private List<CreditCard> cards = new List<CreditCard>();
        private List<Client> clients = new List<Client>();
        private List<string> businesses = new List<string>();

        private CreditCard selectedCard => (cardNumberCB.SelectedItem as Displayer<CreditCard>)?.Item;
        private Client selectedClient => (clientCB.SelectedItem as Displayer<Client>)?.Item;
        private string selectedBusiness => businessNameCB.Text;

        public TransactionWritingScreen(ManagerAgent agent)
        {
            InitializeComponent();
            this.agent = agent;
            cards = agent.GetAllPayersCards();
            clients = agent.GetAllPayerClients();
            businesses = agent.GetAllKnownBusinesses();

            businessNameCB.Items.AddRange(businesses.ToDisplayerList(b => $"{b}").ToArray());
            cardNumberCB.Items.AddRange(cards.ToDisplayerList((c) => {
                return $"{c.CreditCardNumber}";
            }).ToArray());
            clientCB.Items.AddRange(clients.ToDisplayerList((c) => {
                if(c is not null)
                return $"Id: {c.ClientId} Name: {c.FirstName} {c.LastName}";
                return "";
            }).ToArray());

            dateDTP.Value = DateTime.Now;
            dateDTP.MaxDate = DateTime.Now;
        }

        private void TransactionWritingScreen_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (selectedCard is null)
            {
                MessageBox.Show(this, "Card is a must!", "how the client bought?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectedClient is null)
            {
                MessageBox.Show(this, "client is a must!", "Which client bought?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(selectedCard.ClientId==selectedClient.ClientId&&selectedClient.ClientId!=0)
            {
                MessageBox.Show(this, "Client cant pay to himself!", "Recursion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(selectedBusiness=="")
            {
                MessageBox.Show(this, "Business is a must!", "where do the client bought?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (paymentNUD.Value<1&&paymentNUD.Value>-1)
            {
                var dialogresult=MessageBox.Show(this, $"Are you sure you want to proceed with {paymentNUD.Value}₪?","Negliable amount", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogresult != DialogResult.Yes)
                    return;
            }
            var result=agent.AddTransaction(((double)paymentNUD.Value), selectedCard, selectedClient, selectedBusiness, cardShowedCB.Checked);
            if (result == TransactionResult.Succefull)
            {
                MessageBox.Show(this, $"Made transaction from card: {selectedCard.CreditCardNumber}{Environment.NewLine}" +
                    $"At business: {selectedBusiness}{Environment.NewLine}" +
                    $"Amount: {paymentNUD.Value.ToString("N2")}₪{Environment.NewLine}" +
                    $"Client: Id: {selectedClient.ClientId}, Name: {selectedClient.FirstName} {selectedClient.LastName}","GG",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (result == TransactionResult.CardIsCanceled||result==TransactionResult.CardIsRecievingOnly)
                MessageBox.Show(this, "The card is canceled or suspended and can perfom payments", "No GG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (result == TransactionResult.NotEnoughCredit)
                MessageBox.Show(this, "The Card has no enough credit for this payment", "No GG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (result == TransactionResult.UnKnownFailure)
                MessageBox.Show(this, "The transaction could not be completed and threw an unexpected error!", "Thats on us", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cardNumberCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
