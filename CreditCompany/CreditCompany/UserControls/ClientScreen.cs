using CreditCompany.UserControls.Extensions;
using CreditCompanyEF;
using CreditCompanyEF.Proxies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCompany.UserControls
{
    public partial class ClientScreen : UserControl
    {
        private ClientAgent agent;

        /// <summary>
        /// Occurs when the client want an extended detail on his transactions.
        /// </summary>
        public event EventHandler<ClientAgent> ExtendedDetailRequested;
        /// <summary>
        /// Occurs when the client want to send a request to the company.
        /// </summary>
        public event EventHandler<(ClientAgent agent, string title)> RequestSendRequest;

        public ClientScreen(ClientAgent agent)
        {
            try
            {
                InitializeComponent();
                if (agent is null)
                {
                    MessageBox.Show(this, "agent is null!");
                    return;
                }
                this.agent = agent;
                CardListFLP.Controls.Clear();
                TransactionListFLP.Controls.Clear();
            }
            catch (Exception) { }
            foreach (var item in agent.Client.WorkingCards)
            {
                AddCardLabel(item.Club, item.CreditCardNumber.Substring(12), item.Credit, item.Credit - item.UsedCredit);
            }
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month),23,59,59,999);
            foreach (var item in agent.GetTransactionsByDates(startDate, endDate))
            {
                AddTransactLabel(item.Date.Value, item.Business, item.Payment, item.PayerCardNumber.Substring(12));
            }
            TotalCreditLabel.Text = agent.Client.TotalCredit+"₪";
            UsedCreditLabel.Text = agent.Client.UsedCredit + "₪";
            ClientsNameLabel.Text = agent.Client.FirstName + " " + agent.Client.LastName;
            NewCardRequestBtn.CenterHorizontal();
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
                + "מסגרת: " + credit+"₪" + Environment.NewLine
                + "מסגרת פנויה: " +"₪"+ creditLeft;


            CardListFLP.Controls.Add(label);
        }
        private void AddTransactLabel(DateTime date,string business,double? amount,string cardslast4digits)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RequestsToCompanyBtn_Click(object sender, EventArgs e)
        {
            OnRequestSendRequest(agent, "");
        }

        private void OnRequestSendRequest(ClientAgent agent, string title)
        {
            this.RequestSendRequest?.Invoke(this, (agent, title));
        }

        private void NewCardRequestBtn_Click(object sender, EventArgs e)
        {
            OnRequestSendRequest(agent, ClientAgent._titles[((int) RequestsTitles.IssueNewCreditCardRequest)]);
        }

        private void ClientScreen_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread t = new Thread(() =>
            {
                IEnumerable<MessageClientProxy> msgs;
                lock (agent)
                {
                    msgs = agent.Client.MessagesFromCompany.Where(m => m.IsViewed == false || m.IsViewed is null);
                }
                foreach (var item in msgs)
                {
                    MessageBox.Show(this, item.Content, item.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    agent.ViewMessage(item);
                }
            });
            t.Start();
        }

        private void TransactionsBtn_Click(object sender, EventArgs e)
        {
            OnExtendedDetailRequested(agent);
        }

        protected void OnExtendedDetailRequested(ClientAgent agent)
        {
            ExtendedDetailRequested?.Invoke(this, agent);
        }

        private void BlockCardBtn_Click(object sender, EventArgs e)
        {
            OnRequestSendRequest(agent, ClientAgent._titles[((int)RequestsTitles.BlockCreditCardRequest)]);
        }

        private void ClientScreen_Validated(object sender, EventArgs e)
        {
            
        }
    }
}
