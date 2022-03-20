using CreditCompany.UserControls;
using CreditCompanyEF;
using CreditCompanyEF.Models;
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

namespace CreditCompany
{
    public partial class Form1 : Form
    {
        static char[] hebrew = "אבגדהוזחטיכלמנסעפצקרשתףץןך".ToCharArray();
        //Indicates whether the form has been configured or not.
        private bool isConfigured = false;
        private Random rnd = new Random();
        List<UserControl> previous = new List<UserControl>();

        public Form1()
        {
            InitializeComponent();
            InitialConfigurations();
            infoLabel.Text = "";
            //MessageBox.Show(this, "Change the catalog to CreditCompany!", "Change the catalog to CreditCompany!");
            StartLogin();
            //StartClientManageing(ClientAgent.GetClient("Avichay", "123456"),ManagerAgent.GetManager("Avichay","123456"));
            //StartClientIdentity(new UserEventArgs(null,ClientAgent.GetClient("Avichay","123456")));
            //StartTransactWriting(ManagerAgent.GetManager("Avichay", "123456"));
        }

        /// <summary>
        /// Starts the <see cref="EntryScreen"/> screen.
        /// </summary>
        private void StartLogin()
        {
            EntryScreen entryScreen = new EntryScreen();
            ReplaceMainPanel(entryScreen);
            infoLabel.Text = "Login";
            entryScreen.UserRetrieved += (sender,e)=> {
                AfterLoggedIn(e);
            };
            previous.Add(entryScreen);
        }
        /// <summary>
        /// Starts the <see cref="EnterAs"/> screen to choose to enter as client or manager.
        /// </summary>
        /// <param name="user"></param>
        private void AfterLoggedIn(UserEventArgs user)
        {
            EnterAs enterAs = new EnterAs(user);
            ReplaceMainPanel(enterAs);
            infoLabel.Text = "Choose identity";
            enterAs.Entered += (sender, e)=>{
                if (e.IncludesClient())
                    StartClientIdentity(e);
                else if (e.IncludesManager())
                    StartManagerIdentity(e);
                else
                    MessageBox.Show(this, "The user has no identity at all!");
            };
            previous.Add(enterAs);
        }
        /// <summary>
        /// Starts the <see cref="ClientScreen"/> screen.
        /// </summary>
        /// <param name="e"></param>
        private void StartClientIdentity(UserEventArgs e)
        {
            ClientScreen clientScreen = new ClientScreen(e.ClientAgent);
            ReplaceMainPanel(clientScreen);
            infoLabel.Text = $"client: {e.ClientAgent.Client.FirstName} {e.ClientAgent.Client.LastName}";
            previous.Add(clientScreen);
            clientScreen.ExtendedDetailRequested += (sender, e) => {
                StartClientExtendedDetail(e);
            };
            clientScreen.RequestSendRequest += (sender, e) => {
                StartRequestSending(e);
            };
        }
        /// <summary>
        /// Starts the <see cref="ManagerScreen"/> screen.
        /// </summary>
        /// <param name="e"></param>
        private void StartManagerIdentity(UserEventArgs e)
        {
            ManagerScreen managerScreen = new ManagerScreen(e.ManagerAgent);
            ReplaceMainPanel(managerScreen);
            infoLabel.Text = $"Manage it {e.ManagerAgent.Manager.ManagerName}!";
            managerScreen.ClientCaught += (sender, e) => {
                StartClientManageing(e.Client,e.Manager);
            };
            managerScreen.TransactionWriteAsked += (sender, e) => {
                StartTransactWriting(e);
            };
            managerScreen.AddUserAsked += (sender,e1) => {
                StartUserAdditor(e.ManagerAgent);
            };
            previous.Add(managerScreen);
        }
        /// <summary>
        /// Starts the <see cref="UserAdditorScreen"/>.
        /// </summary>
        /// <param name="managerAgent">The agent to handlr the addition.</param>
        private void StartUserAdditor(ManagerAgent managerAgent)
        {
            UserAdditorScreen screen = new UserAdditorScreen(managerAgent);
            ReplaceMainPanel(screen);
            infoLabel.Text = "More client= more money";
            previous.Add(screen);
        }
        /// <summary>
        /// Starts the screen for writing transactions.
        /// </summary>
        /// <param name="e">The agent which can do the writing.</param>
        private void StartTransactWriting(ManagerAgent e)
        {
            TransactionWritingScreen screen = new TransactionWritingScreen(e);
            ReplaceMainPanel(screen);
            infoLabel.Text = "Be carefull...";
            previous.Add(screen);
        }
        /// <summary>
        /// Starts a <see cref="ClientScreenManage"/> screen.
        /// </summary>
        /// <param name="clientAgent">The client to manage.</param>
        /// <param name="managerAgent">The manager who manage.</param>
        private void StartClientManageing(ClientAgent clientAgent,ManagerAgent managerAgent)
        {
            ClientScreenManage clientScreenManage = new ClientScreenManage(clientAgent, managerAgent);
            ReplaceMainPanel(clientScreenManage);
            infoLabel.Text = "Manage the client boss.";
            previous.Add(clientScreenManage);
            clientScreenManage.ExtendedDetailAsked += (sender, d) => {
                StartClientExtendedDetailManaging(d.clientAgent, d.managerAgent);
            };
        }
        /// <summary>
        /// Starts the <see cref="ClientExtendedDetailManage"/> screen.
        /// </summary>
        /// <param name="clientAgent"></param>
        /// <param name="managerAgent"></param>
        private void StartClientExtendedDetailManaging(ClientAgent clientAgent, ManagerAgent managerAgent)
        {
            ClientExtendedDetailManage clientExtendedDetailManageScreen = new ClientExtendedDetailManage(managerAgent,clientAgent);
            ReplaceMainPanel(clientExtendedDetailManageScreen);
            infoLabel.Text = $"Client: {clientAgent.Client.FirstName + " " + clientAgent.Client.LastName}";
            previous.Add(clientExtendedDetailManageScreen);
        }
        /// <summary>
        /// Starts <see cref="RequestScreen"/> screen.
        /// </summary>
        /// <param name="e">The required information to start the screen.</param>
        private void StartRequestSending((ClientAgent agent, string title) e)
        {
            RequestScreen screen = new RequestScreen(e.agent, e.title);
            ReplaceMainPanel(screen);
            infoLabel.Text = "We've got your back";
            previous.Add(screen);
        }
        /// <summary>
        /// Start the <see cref="ClientTransactionDetails"/> screen for client.
        /// </summary>
        /// <param name="e"></param>
        private void StartClientExtendedDetail(ClientAgent e)
        {
            ClientTransactionDetails details = new ClientTransactionDetails(e);
            ReplaceMainPanel(details);
            previous.Add(details);
            infoLabel.Text = "thats all we've got";
        }

        /// <summary>
        /// The initial configuration for the form.
        /// </summary>
        private void InitialConfigurations()
        {
            if (isConfigured)
                return;
            //implementing the rtl of the text.
            infoLabel.TextChanged += (sender, e) => {
                if (infoLabel.Text.Length > 0)
                {
                    if (hebrew.Contains(infoLabel.Text[0]))
                        infoLabel.TextAlign = ContentAlignment.MiddleRight;
                    else
                        infoLabel.TextAlign = ContentAlignment.MiddleLeft;
                }
            };
            //Enforces only one control at a time.
            mainPanel.ControlAdded += (sender, e) =>
            {
                if (mainPanel.Controls.Count > 1)
                    throw new TooMuchControlsException("The main panel cant have more than 1 controls.");
                else if (mainPanel.Controls.Count > 0) 
                {
                    mainPanel.Size = mainPanel.Controls[0].Size;
                }
            };
        }
        /// <summary>
        /// Replaces the control in the main panel.
        /// </summary>
        /// <param name="replacer"></param>
        private void ReplaceMainPanel(Control replacer)
        {
            //if (mainPanel.Controls.Count == 1)
            //    mainPanel.Controls[0].Dispose();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(replacer);
        }
        private void infoLabel_Click(object sender, EventArgs e)
        {
            //button1_Click(sender, e);

            //StartLogin();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (previous.Count == 1)
                return;
            var prev = previous[previous.Count - 2];
            previous.Remove(previous[previous.Count - 1]);
            ReplaceMainPanel(prev);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
