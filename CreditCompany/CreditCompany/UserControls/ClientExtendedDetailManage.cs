using CreditCompanyEF;
using CreditCompanyEF.Proxies;
using CreditCompanyEF.Proxies.Extensions;
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
    public partial class ClientExtendedDetailManage : UserControl
    {
        private ClientAgent clientAgent;
        private ManagerAgent managerAgent;
        private List<TransactionClientProxy> transactionsList;
        private TransactionClientProxy selectedTransaction => extendedDetailLabel.transaction;


        public ClientExtendedDetailManage(ManagerAgent managerAgent,ClientAgent clientAgent)
        {
            InitializeComponent();
            this.clientAgent = clientAgent;
            this.managerAgent = managerAgent;
            if (clientAgent is null || managerAgent is null)
            {
                MessageBox.Show(this, "agent is null!");
                return;
            }
            this.clientAgent = clientAgent;

            BasicSearch();

            ClientsNameLabel.Text = clientAgent.Client.FirstName + " " + clientAgent.Client.LastName;
        }
        private void SelectTransactionByDates(DateTime startDate, DateTime endDate)
        {
            //TransactionListFLP.Controls.Clear();
            transactionsList = transactionsList.Where((item) =>
            {
                return item.Date > startDate && item.Date < endDate;
            }).ToList();

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

            foreach (var item in transactionsList)//clientAgent.GetTransactionsByDates(startDate, endDate))
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
            transactionsList = clientAgent.GetTransactionsByDates(startDate, endDate);
            SelectTransactionByDates(startDate, endDate);
        }

        private void DenyTransaction(object sender, EventArgs e)
        {
            if (extendedDetailLabel.transaction.IsDenied)
            {
                MessageBox.Show(this, "The transaction has been asked before to be refunded.", "Cant deny this.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Form f = new Form();
                RequestScreen requestScreen = new RequestScreen(clientAgent, ClientAgent._titles[((int)RequestsTitles.DenyTransactionRequest)], GetBaseDenyAsk(extendedDetailLabel.transaction));
                //requestScreen.Dock = DockStyle.Fill;
                f.AutoSize = true;
                f.AutoSizeMode = AutoSizeMode.GrowOnly;
                f.Controls.Add(requestScreen);
                f.ShowDialog(this);
                if (requestScreen.IsSubmitted)
                {
                    clientAgent.DenyTransactionAsync(extendedDetailLabel.transaction, requestScreen.Request);
                }
            }
        }
        private string GetBaseDenyAsk(TransactionClientProxy transaction)
        {
            return $"I wish to deny the transaction number: {transaction.TransactionId}" + Environment.NewLine +
                 $"which been done at {transaction.Date}" + Environment.NewLine +
                 $"at business: {transaction.Business}";
        }
        private void ExtendDetail(object sender, EventArgs e)
        {
            if (sender is TransactionLabel label)
            {
                var trans = label.transaction;
                var text = "פרטי עסקה:" + Environment.NewLine;
                text += "מספר עסקה:" + trans.TransactionId + Environment.NewLine;
                text += "תאריך:" + trans.Date?.ToString("dd.MM.yyyy") + Environment.NewLine;
                text += "סכום: " + trans.Payment + "₪" + Environment.NewLine;
                text += "עסק: " + trans.Business + Environment.NewLine;
                text += "כרטיס הוצג: " + (trans.CardShowed == true ? "כן" : "לא") + Environment.NewLine;
                extendedDetailLabel.Text = text;
                extendedDetailLabel.transaction = trans;
                if (trans.Payment <= 0)
                {
                    refundTransactionBtn.Enabled = false;
                    refundTransactionBtn.Visible = false;
                }
                else
                {
                    refundTransactionBtn.Enabled = true;
                    refundTransactionBtn.Visible = true;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void ClientTransactionDetails_Load(object sender, EventArgs e)
        {

        }

        private void datePickerBtn_Click(object sender, EventArgs e)
        {
            var dates = DatesPicker.GetDates(this);
            if (dates is not null)
                SelectTransactionByDates(dates.Value.start, dates.Value.end);
        }

        private void clearSearchBtn_Click(object sender, EventArgs e)
        {
            BasicSearch();
        }

        private void denyTransactionBtn_Click(object sender, EventArgs e)
        {
            string title = "refund of transaction.";
            string content = $"we decided to refund you the transaction you made.{Environment.NewLine}" +
                $"which has been made at: {selectedTransaction.Date?.ToString("dd/MM/yyyy HH/mm/ss") + Environment.NewLine}" +
                $"business: {selectedTransaction.Business}{Environment.NewLine}" +
                $"last 4 digits of the card used: {selectedTransaction.PayerCardNumber.Substring(12)}{Environment.NewLine}";
            RefundTransaction refundScreen = new RefundTransaction(managerAgent, selectedTransaction,title,content);
            Form f = new Form();
            f.AutoSize = true;
            f.Controls.Add(refundScreen);
            f.ShowDialog(this);
        }

        private void cardPickerBtn_Click(object sender, EventArgs e)
        {
            var card=CardsPicker.ChooseCard(this, managerAgent.ToCreditCardList(clientAgent.Client.CreditCards).ToProxyList());
            SelectTransactionByCard(card);
        }

        private void transactionLabelInstance_Click(object sender, EventArgs e)
        {

        }

        private void ClientExtendedDetailManage_Load(object sender, EventArgs e)
        {

        }
    }
}
