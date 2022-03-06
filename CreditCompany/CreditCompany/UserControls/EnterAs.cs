using CreditCompany.UserControls.Extensions;
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
    public partial class EnterAs : UserControl
    {
        private UserEventArgs user;

        /// <summary>
        /// Occurs when the user choose identity.
        /// </summary>
        public event EventHandler<UserEventArgs> Entered;

        public EnterAs(UserEventArgs user)
        {
            this.user = user;
            InitializeComponent();
            panel1.CenterHorizontal();
            EAClientBtn.Enabled = user.IncludesClient();
            EAManagerBtn.Enabled = user.IncludesManager();
        }

        private void EAClientBtn_Click(object sender, EventArgs e)
        {
            //user.ManagerAgent = null;
            OnEntered(new UserEventArgs(null,user.ClientAgent));
        }

        private void EAManagerBtn_Click(object sender, EventArgs e)
        {
            //user.ClientAgent = null;
            OnEntered(new UserEventArgs(user.ManagerAgent, null));
        }

        protected void OnEntered(UserEventArgs user)
        {
            this.Entered?.Invoke(this, user);
        }
    }
}
