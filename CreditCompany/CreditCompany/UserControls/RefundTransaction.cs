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
    public partial class RefundTransaction : UserControl
    {
        private ManagerAgent agent;
        private Transaction selectedTransaction => GetSelectedTransaction();

        private Transaction GetSelectedTransaction()
        {
            var t = TransactToRefundCB.SelectedItem as TransactionDisplay;
            if (t is null||t.transaction is null)
                return null;
            return agent.GetTransaction(t.transaction);
        }

        public RefundTransaction(ManagerAgent agent, TransactionClientProxy transaction, string title="", string content="")
        {
            InitializeComponent();
            this.agent = agent;
            //this.transaction = agent.GetTransaction(transaction);
            titleBoxTB.Text = title;
            contentBoxTB.Text = content;

            label3.CenterHorizontal();
            label2.CenterHorizontal();
            submitBtn.CenterHorizontal();


            var transactions = transaction.RecieverClient.Transactions;
            var arr = TransactionDisplay.ToDisplayArray(transactions);
            TransactToRefundCB.Items.AddRange(arr);
            TransactToRefundCB.SelectedIndexChanged += (sender, e) => {
                contentBoxTB.Text = GetTransactionText(TransactionClientProxy.GetProxy(selectedTransaction));
            };
            TransactToRefundCB.SelectedIndex = TransactToRefundCB.Items.IndexOf(arr.Where((item) =>
            {
                return item.transaction == transaction;
            }).ElementAt(0));
        }
        private string GetTransactionText(TransactionClientProxy t)
        {
            return $"we decided to refund you the transaction you made.{Environment.NewLine}" +
                $"which has been made at: {t.Date?.ToString("dd/MM/yyyy HH/mm/ss") + Environment.NewLine}" +
                $"business: {t.Business}{Environment.NewLine}" +
                $"last 4 digits of the card used: {t.PayerCardNumber.Substring(12)}{Environment.NewLine}";
        }
        private string GetRequestText(RequestsFromClient request)
        {
            return $"מספר לקוח: {request.ClientId}{Environment.NewLine}" +
                            $"{request.Title}{Environment.NewLine}" +
                            $"{request.Content}";
        }
        private void RefundTransaction_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            agent.RefundTransaction(selectedTransaction);
            agent.AddMesasge(titleBoxTB.Text, contentBoxTB.Text, selectedTransaction.ReciverClient);
            MessageBox.Show(this, "The transaction has been refunded!", "0 mistakes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var p=this.Parent as Form;
            p.Close();
        }

        private void requestRespondBtn_Click(object sender, EventArgs e)
        {
            var r=RequestFromClientPicker.Pick(this, selectedTransaction.ReciverClient.RequestsFromClients);
            if (r is not null)
            {
                respondRequestLabel.request = r;
                respondRequestLabel.Text = GetRequestText(r);
            }
            else
            {
                respondRequestLabel.request = null;
                respondRequestLabel.Text = "";
            }
        }

    }
    public class TransactionDisplay
    {
        public TransactionClientProxy transaction;

        public TransactionDisplay(TransactionClientProxy transaction)
        {
            this.transaction = transaction;
        }
       // public TransactionDisplay

        public override string ToString()
        {
            return $"Id: {transaction.TransactionId}, Amount: {transaction.Payment?.ToString("N2")}₪";
        }

        public static TransactionDisplay[] ToDisplayArray(IEnumerable<TransactionClientProxy> transactions)
        {
            TransactionDisplay[] r = new TransactionDisplay[transactions.Count()];
            int index = 0;
            foreach (var item in transactions)
            {
                r[index++]=new TransactionDisplay(item);
            }
            return r;
        }
    }
}
