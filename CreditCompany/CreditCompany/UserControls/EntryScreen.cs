using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreditCompanyEF;
using CreditCompany.UserControls.Extensions;
using CreditCompanyEF.Models;
using System.Threading;

namespace CreditCompany.UserControls
{
    public partial class EntryScreen : UserControl
    {
        /// <summary>
        /// Occurs when the client enter his user name and password correctly.
        /// </summary>
        public event EventHandler<UserEventArgs> UserRetrieved;

       // private bool finishedConnectToDBs = false;

        public EntryScreen()
        {
            InitializeComponent();
            foreach (var item in this.Controls)
            {
                if (item is Control control)
                    this.Resize += (sender, e) =>
                    {
                        control.CenterHorizontal();
                    };
            }
            ConnectToDatabase();
            OnResize(new EventArgs());
        }

        private void ConnectToDatabase()
        {
            Thread t = new Thread(() => {
                var context = new CreditCompanyContext();
                //Making sure the data base has been created.
                context.Database.EnsureCreated();
                //context.SaveChanges();
                //finishedConnectToDBs = true;
            });
            t.Start();
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            
            ClientAgent cAgent = ClientAgent.GetClient(userNameTB.Text, passwordTB.Text);
            ManagerAgent mAgent = ManagerAgent.GetManager(userNameTB.Text, passwordTB.Text);
            if (cAgent is null&&mAgent is null)
                MessageBox.Show(this, "User does not exists!", "user? what user?", MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            {
                OnUserFound(cAgent, mAgent);
            }
        }
        /// <summary>
        /// Raises the <see cref="EntryScreen.UserRetrieved"/>.
        /// </summary>
        /// <param name="c">The client agent.</param>
        /// <param name="m">The manager agent.</param>
        protected void OnUserFound(ClientAgent c,ManagerAgent m)
        {
            //while (this.finishedConnectToDBs == false)
            //{
            //    Thread.Sleep(1);
            //}
            UserRetrieved?.Invoke(this, new UserEventArgs(m,c));
        }

        private void EntryScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
