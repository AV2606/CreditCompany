using CreditCompany.UserControls.Extensions;
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
    public partial class ClientScreenManage : UserControl
    {
        private ManagerAgent managerAgent;
        private ClientAgent clientAgent;
        
        /// <summary>
        /// Occurs when the user asks for extended details on the client.
        /// </summary>
        public event EventHandler<(ClientAgent clientAgent, ManagerAgent managerAgent)> ExtendedDetailAsked;

        public ClientScreenManage(ClientAgent clientAgent,ManagerAgent managerAgent)
        {
            InitializeComponent();
            if (clientAgent is null ||   managerAgent is null)
            {
                MessageBox.Show(this, "agent is null!");
                return;
            }
            this.managerAgent = managerAgent;
            this.clientAgent = clientAgent;
            CardListFLP.Controls.Clear();
            TransactionListFLP.Controls.Clear();

            foreach (var item in clientAgent.Client.CreditCards)
            {
                AddCardLabel(item.Club, item.CreditCardNumber.Substring(12), item.Credit, item.Credit - item.UsedCredit);
            }
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59, 999);
            foreach (var item in clientAgent.GetTransactionsByDates(startDate, endDate))
            {
                AddTransactLabel(item.Date.Value, item.Business, item.Payment, item.PayerCardNumber.Substring(12));
            }
            TotalCreditLabel.Text = clientAgent.Client.TotalCredit + "₪";
            UsedCreditLabel.Text = clientAgent.Client.UsedCredit + "₪";
            ClientsNameLabel.Text = clientAgent.Client.FirstName + " " + clientAgent.Client.LastName;
            NewCardRequestBtn.CenterHorizontal();
            var score= managerAgent.GetCreditScore(clientAgent) + "";
            CreditScoreLabel.Text = score;
            var date= managerAgent.GetStartDate(clientAgent).ToString("dd.MM.yyyy");
            startDateLabel.Text = date;
        }
        private void AddCardLabel(string club, string last4digits, double? credit, double? creditLeft)
        {
            Label label = new Label();
            label.Font = cardLabelInstance.Font;
            label.BackColor = cardLabelInstance.BackColor;
            label.ForeColor = cardLabelInstance.ForeColor;
            label.Dock = cardLabelInstance.Dock;
            label.RightToLeft = cardLabelInstance.RightToLeft;
            label.AutoSize = transactionLabelInstance.AutoSize;
            label.Visible = true;

            label.Text = "מועדון: " + club + Environment.NewLine
                + "מסתיים בספרות:" + last4digits + Environment.NewLine
                + "מסגרת: " + credit + "₪" + Environment.NewLine
                + "מסגרת פנויה: " + "₪" + creditLeft;


            CardListFLP.Controls.Add(label);
        }
        private void AddTransactLabel(DateTime date, string business, double? amount, string cardslast4digits)
        {
            Label label = new Label();
            label.Font = transactionLabelInstance.Font;
            label.BackColor = transactionLabelInstance.BackColor;
            label.ForeColor = transactionLabelInstance.ForeColor;
            label.Dock = transactionLabelInstance.Dock;
            label.RightToLeft = transactionLabelInstance.RightToLeft;
            label.AutoSize = transactionLabelInstance.AutoSize;
            label.Visible = true;

            label.Text = date.ToString("dd/MM/yyyy") + ", ב" + business + ":" + amount + "₪" + Environment.NewLine
                + "בכרטיס שמסתיים בספרות:" + cardslast4digits;

            TransactionListFLP.Controls.Add(label);
        }

        private void BlockCardBtn_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.AutoSize = true;
            ManagerCardAction cardAction = new ManagerCardAction(managerAgent, clientAgent, HoldCard);
            cardAction.Submitted += (sender, e) => {
                f.Close();
            };
            f.Text = "Hold card form";
            f.Controls.Add(cardAction);
            f.ShowDialog();
        }

        private void startDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void ClientScreenManage_Load(object sender, EventArgs e)
        {

        }

        private void CardCancelBtn_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.AutoSize = true;
            ManagerCardAction cardAction = new ManagerCardAction(managerAgent, clientAgent, CancelCard);
            cardAction.Submitted += (sender, e) => {
                f.Close();
            };
            f.Text = "Cancel card form";
            f.Controls.Add(cardAction);
            f.ShowDialog();
        }



        private void CancelCard(CreditCardClientProxy card, RequestsFromClient respondRequest, string title, string content)
        {
            managerAgent.CancelCard(card);
            if(respondRequest is not null)
            managerAgent.MarkAsAnswered(respondRequest);
            managerAgent.AddMesasge(title, content, card);
        }
        private void HoldCard(CreditCardClientProxy card, RequestsFromClient respondRequest, string title, string content)
        {
            managerAgent.HoldCard(card);
            if(respondRequest is not null)
            managerAgent.MarkAsAnswered(respondRequest);
            managerAgent.AddMesasge(title, content, card);
        }

        private void NewCardRequestBtn_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            IssueNewCardScreen screen = new IssueNewCardScreen(managerAgent,managerAgent.GetClientByAgent(clientAgent));
            f.AutoSize = true;
            f.Controls.Add(screen);
            f.ShowDialog();
        }

        private void TransactionsBtn_Click(object sender, EventArgs e)
        {
            OnExtendedDetailAsked((clientAgent,managerAgent));
        }

        private void OnExtendedDetailAsked((ClientAgent clientAgent, ManagerAgent managerAgent) data)
        {
            ExtendedDetailAsked?.Invoke(this, data);
        }
    }
}
