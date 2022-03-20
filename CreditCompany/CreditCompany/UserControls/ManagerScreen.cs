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

    public partial class ManagerScreen : UserControl
    {
        private ManagerAgent agent;
        private RequestLabel selected;

        /// <summary>
        /// Raises when the manager asked to write transactions.
        /// </summary>
        public event EventHandler<ManagerAgent> TransactionWriteAsked;
        /// <summary>
        /// Indicates that the <see cref="ClientsInfoBtn"/> has been clicked and all the data is valid.
        /// </summary>
        public event EventHandler<(ClientAgent Client,ManagerAgent Manager)> ClientCaught;
        /// <summary>
        /// Occurs when the user clicked to add a new user.
        /// </summary>
        public event EventHandler AddUserAsked;

        public ManagerScreen(ManagerAgent managerAgent)
        {
            InitializeComponent();
            this.agent = managerAgent;
            List<RequestsFromClient> requests= agent.GetRequestsFromClients();
            AssignRequests(requests);
            //RequestLabelInstance.Width = RequestsFLP.Width;
            RequestsFLP.ControlAdded += (sender, e) => {
                //e.Control.Width = RequestsFLP.Width;
            };
        }

        protected void OnClientCaught(ClientAgent client)
        {
            ClientCaught?.Invoke(this, (client,agent));
        }

        private void AssignRequests(IEnumerable<RequestsFromClient> requests)
        {
            RequestsFLP.Controls.Clear();
            foreach (var item in requests)
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
        private string GetRequestText(RequestsFromClient request)
        {
            return $"מספר לקוח: {request.ClientId}{Environment.NewLine}" +
                            $"{request.Title}{Environment.NewLine}" +
                            $"{request.Content}";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RequestLabelClick(object sender, EventArgs e)
        {
            var label = (RequestLabel)sender;
            selected = label;
            ClientIdTB.Text = ""+label.request.ClientId;
        }

        private void ClientsInfoBtn_Click(object sender, EventArgs e)
        {
            if (selected is not null)
                selected.request.HasBeenViewd = true;
            int i = Convert.ToInt32(ClientIdTB.Text);
            Client c = agent.GetClientById(i);
            if (i == 0||c is null)
            {
                MessageBox.Show(this, "Client not found", "Who is this?", MessageBoxButtons.OK);
                return;
            }
            var users = c.Users;
            OnClientCaught(ClientAgent.GetClient(users.ElementAt(0).UserName, users.ElementAt(0).UserPassword));
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            var f=Filter.GetFilter(this);
            AssignRequests(agent.GetRequestsFromClients(f.id, f.title));
        }

        private void ManagerScreen_Load(object sender, EventArgs e)
        {

        }

        private void ManagerScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(this, "clicked key: " + e.KeyChar, "click",MessageBoxButtons.OK);
        }

        private void RequestLabelInstance_DoubleClick(object sender, EventArgs e)
        {
            if (sender is RequestLabel l)
            {
                var result=MessageBox.Show(this, GetRequestText(l.request), "Mark request as answered?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    l.request.HasBeenViewd = true;
                    l.request.Answered = true;
                }
            }
        }

        private void TransactBtn_Click(object sender, EventArgs e)
        {
            OnTransactionWriteAsked(agent);
        }

        protected void OnTransactionWriteAsked(ManagerAgent agent)
        {
            TransactionWriteAsked?.Invoke(this, agent);
        }

        private void UserAdderBtn_Click(object sender, EventArgs e)
        {
            OnAddUserAsked();
        }

        protected void OnAddUserAsked()
        {
            AddUserAsked?.Invoke(this,EventArgs.Empty);
        }
    }
}
