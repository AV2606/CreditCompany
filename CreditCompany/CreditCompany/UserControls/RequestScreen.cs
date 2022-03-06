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
    /// <summary>
    /// The action that should be invoked when <see cref="RequestScreen.submitBtn"/> is pressed.
    /// </summary>
    /// <param name="title">The title of the request submitted.</param>
    /// <param name="content">The content of the request submitted.</param>
    /// <returns>
    /// a bool value indicates whether the action was invoked succefully or not.
    /// </returns>
    public delegate bool SubmitAction(string title, string content);

    public partial class RequestScreen : UserControl
    {
        private ClientAgent agent;
        private SubmitAction action;
        private bool isSubmitted = false;
        /// <summary>
        /// Indiactes whether the request has been submitted or not, independent of if the
        /// action was provided by the user or not.
        /// </summary>
        public bool IsSubmitted => isSubmitted;
        private RequestsFromClient request = null;
        /// <summary>
        /// The request that submitted, if submitted.
        /// </summary>
        public RequestsFromClient Request => request;


        public RequestScreen(ClientAgent agent,string title="",string content="",SubmitAction submitFunc=null)
        {
            InitializeComponent();
            foreach (Control item in this.Controls)
            {
                item.CenterHorizontal();
            }
            this.agent = agent;
            this.titleBoxTB.Text = title;
            this.contentBoxTB.Text = content;
            if (submitFunc is null)
            {
                this.action = (title, content) => {
                    request = agent.SendRequest(title, content);
                    return request is not null;
                };
            }
            else
                this.action = submitFunc;
        }

        private void RequestScreen_Load(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (action(titleBoxTB.Text, contentBoxTB.Text) == false)
                MessageBox.Show(this, "The message was not send...", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isSubmitted = true;
                MessageBox.Show(this, "Message sent succefully", "We got you covered.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form p = this.Parent as Form;
                if (p is not null)
                    p.Close();
            }
        }
    }
}
