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
    public partial class RequestFromClientPicker : UserControl
    {
        List<RequestsFromClient> requests = new List<RequestsFromClient>();
        RequestsFromClient answer = null;

        private RequestFromClientPicker(IEnumerable<RequestsFromClient> reqs)
        {
            InitializeComponent();
            this.requests = reqs.ToList();

            RequestsFLP.Controls.Clear();

            foreach (var item in reqs)
            {
                AddRequestLabel(item);
            }
        }
        private void AddRequestLabel(RequestsFromClient request)
        {
            RequestLabel label = new RequestLabel();
            label.Font = RequestLabelInstance.Font;
            label.BackColor = RequestLabelInstance.BackColor;
            label.ForeColor = RequestLabelInstance.ForeColor;
            label.Dock = RequestLabelInstance.Dock;
            label.RightToLeft = RequestLabelInstance.RightToLeft;
            label.AutoSize = RequestLabelInstance.AutoSize;
            label.Visible = true;
            label.request = request;
            label.Click += RequestLabelClick;
            label.DoubleClick += RequestLabelInstance_DoubleClick;
            label.Margin = RequestLabelInstance.Margin;

            label.Text = GetRequestText(request);

            RequestsFLP.Controls.Add(label);
        }

        private void RequestLabelInstance_DoubleClick(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void RequestLabelClick(object sender, EventArgs e)
        {
            RequestLabel label = sender as RequestLabel;
            if(label is null)
            {
                return;
            }
            chosenLabel.Text = GetRequestText(label.request);
            chosenLabel.request = label.request;
        }

        private string GetRequestText(RequestsFromClient request)
        {
            return $"מספר לקוח: {request.ClientId}{Environment.NewLine}" +
                            $"{request.Title}{Environment.NewLine}" +
                            $"{request.Content}";
        }
        private void RequestFromClientPicker_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            answer = chosenLabel.request;

            if(answer is null)
            {
                MessageBox.Show(this, "Cant find the request", "what request?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var p = this.Parent as Form;
            p.Close();
        }

        /// <summary>
        /// Picks a request from the user by a ui control.
        /// </summary>
        /// <param name="owner">The owner of this dialog.</param>
        /// <param name="requests">a list of the possible requests.</param>
        /// <returns>The request chosen or null if non has been chosen.</returns>
        public static RequestsFromClient Pick(IWin32Window owner,IEnumerable<RequestsFromClient> requests)
        {
            RequestFromClientPicker picker = new RequestFromClientPicker(requests);
            Form f = new Form();
            f.AutoSize = true;
            f.Controls.Add(picker);
            f.ShowDialog(owner);
            if (picker.answer is not null)
                return picker.answer;
            return null;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            answer = null;

            var p = this.Parent as Form; ;
            p.Close();
        }
    }
}
