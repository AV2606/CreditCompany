using CreditCompanyEF;
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
    public partial class ClientTransactionDetails : UserControl
    {
        private ClientAgent agent;
        private List<TransactionClientProxy> transactionsList = new List<TransactionClientProxy>();

        public event EventHandler<TransactionClientProxy> TransactionDenied;
        public ClientTransactionDetails(ClientAgent agent)
        {
            InitializeComponent();
            TransactionDenied += (sender, e) => {
                DenyTransaction(sender, null);
            };
            this.agent = agent;
            if (agent is null)
            {
                MessageBox.Show(this, "agent is null!");
                return;
            }
            this.agent = agent;

            

            BasicSearch();

            ClientsNameLabel.Text = agent.Client.FirstName + " " + agent.Client.LastName;
        }
        private void SelectTransactionsByDate(DateTime startDate, DateTime endDate)
        {
            //TransactionListFLP.Controls.Clear();
            transactionsList = agent.GetTransactionsByDates(startDate, endDate);
            ShowTransactions();
        }
        private void SelectTransactionByCard(CreditCardClientProxy card)
        {
            transactionsList = transactionsList.Where((item) => {
                return item.PayerCardNumber == card.CreditCardNumber;
            }).ToList();

            ShowTransactions();
        }

        private void ShowTransactions()
        {
            TransactionListFLP.Controls.Clear();
            foreach (var item in transactionsList)//agent.GetTransactionsByDates(startDate, endDate))
            {
                AddTransactLabel(item.Date.Value, item.Business, item.Payment, item.PayerCardNumber.Substring(12), item);
            }
        }

        private void AddTransactLabel(DateTime date, string business, double? amount, string cardslast4digits, TransactionClientProxy item)
        {
            TransactionLabel label = new TransactionLabel();
            label.FlatStyle = transactionLabelInstance.FlatStyle;
            label.Margin = transactionLabelInstance.Margin;
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

            label.transaction = item;

            label.Click += ExtendDetail;
        }
        private void BasicSearch()
        {
            TransactionListFLP.Controls.Clear();
            extendedDetailLabel.Text = "";
            extendedDetailLabel.transaction = null;
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59, 999);
            //transactionsList = agent.GetTransactionsByDates(startDate, endDate);
            SelectTransactionsByDate(startDate, endDate);
        }

        private void OnTransactionDenied(TransactionClientProxy transaction)
        {
            this.TransactionDenied?.Invoke(this, transaction);
        }
        private void DenyTransaction(object sender,EventArgs e)
        {
            if(extendedDetailLabel.transaction.IsDenied)
            {
                MessageBox.Show(this, "The transaction has been asked before to be refunded.", "Cant deny this.", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                Form f = new Form();
                RequestScreen requestScreen = new RequestScreen(agent,ClientAgent._titles[((int)RequestsTitles.DenyTransactionRequest)],GetBaseDenyAsk(extendedDetailLabel.transaction));
                //requestScreen.Dock = DockStyle.Fill;
                f.AutoSize = true;
                f.AutoSizeMode = AutoSizeMode.GrowOnly;
                f.Controls.Add(requestScreen);
                f.ShowDialog(this);
                if (requestScreen.IsSubmitted)
                {
                     agent.DenyTransactionAsync(extendedDetailLabel.transaction, requestScreen.Request);
                }
            }
        }
        private string GetBaseDenyAsk(TransactionClientProxy transaction)
        {
            return $"I wish to deny the transaction number: {transaction.TransactionId}" +Environment.NewLine+
                 $"which been done at {transaction.Date}" +Environment.NewLine+
                 $"at business: {transaction.Business}";
        }
        private void ExtendDetail(object sender, EventArgs e)
        {
            if (sender is TransactionLabel label)
            {
                var trans = label.transaction;
                var text = "פרטי עסקה:" + Environment.NewLine;
                text += "מספר עסקה:" + trans.TransactionId +Environment.NewLine;
                text += "תאריך:" +trans.Date?.ToString("dd.MM.yyyy")+ Environment.NewLine;
                text += "סכום: " + trans.Payment + "₪" + Environment.NewLine;
                text += "עסק: " + trans.Business + Environment.NewLine;
                text += "כרטיס הוצג: " + (trans.CardShowed == true ? "כן" : "לא") + Environment.NewLine;
                extendedDetailLabel.Text = text;
                extendedDetailLabel.transaction = trans;
                if (trans.Payment <= 0)
                {
                    denyTransactionBtn.Enabled = false;
                    denyTransactionBtn.Visible = false;
                }
                else
                {
                    denyTransactionBtn.Enabled = true;
                    denyTransactionBtn.Visible = true;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DenyTransaction(sender, e);
            OnTransactionDenied(extendedDetailLabel.transaction);
        }

        private void ClientTransactionDetails_Load(object sender, EventArgs e)
        {

        }

        private void datePickerBtn_Click(object sender, EventArgs e)
        {
            var dates=DatesPicker.GetDates(this);
            if (dates is not null)
                SelectTransactionsByDate(dates.Value.start, dates.Value.end);
        }

        private void clearSearchBtn_Click(object sender, EventArgs e)
        {
            BasicSearch();
        }

        private void cardPickerBtn_Click(object sender, EventArgs e)
        {
            var card = CardsPicker.ChooseCard(this, agent.Client.CreditCards);
            SelectTransactionByCard(card);
        }
    }
}
