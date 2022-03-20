using CreditCompanyEF;
using CreditCompanyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCompany
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Form f = new Form1();
             //f.Show();
            //ManagerAgent agent =  ManagerAgent.GetManager("Avichay","123456");
            //ClientAgent clientAgent = ClientAgent.GetClient("Avichay", "123456");
            //var accounts = clientAgent.GetAccounts();
            //accounts.ForEach((a) => { agent.Detach(a); });
            //var c=agent.AddCreditCard(1000, accounts[0], "מיוחד", true);
            //agent.AttachClient(c, clientAgent);
            //agent.SaveChanges();
        }
    }
}
