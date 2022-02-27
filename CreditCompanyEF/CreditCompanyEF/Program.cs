using System;
using Microsoft.EntityFrameworkCore;
using CreditCompanyEF.Models;
using System.Linq;
using CreditCompanyEF.Proxies;
using System.Threading.Tasks;

namespace CreditCompanyEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Main2();
            /*
           // //goto AddClient;

           ////DONE //TODO: Remove Client, and a safe way to do so, added a client for deleted data in id -1.

           // var agent = new ManagerAgent();

           // User user = new User();
           // user.UserName = "Some";
           // user.UserPassword = "123";
           // //TODO: Add messages adder

           // //var t=agent.AddClientAsync(800, "Some", "Some", new CreditCard[] { agent.AddCreditCard(1000, agent.GetRandomAccount()) }, user);
           // //t.Wait();


           // //AddClient:
           // using (var context=new CreditCompanyContext())
           // {
           //     Client c = context.Find(typeof(Client), 3) as Client;
           //     context.Clients.Remove(c);
           //     CreditCard cd = context.Find(typeof(CreditCard), "4580375589901111") as CreditCard;
           //     context.CreditCards.Remove(cd);
           //     context.SaveChanges();
           //     goto End;


           //     
           //     var client = new Client();
           //     client.AssignDate = DateTime.Now;
           //     client.CreditScore = 0;
           //     client.FirstName = "Deleted";
           //     client.LastName = "Client";
           //     client.ClientId = -1;
           //     context.Add(client);
           //     context.SaveChanges();
           // CreditCard card = new CreditCard();
           // card.CreditCardNumber = "4580375589901111";
           // card.Client = client;
           // card.Credit = 1000;
           // card.UsedCredit = 800;
           // card.IsCanceled = false;
           // card.IsRecievingOnly = false;
           // card.Club = "Default";

           // Account account = new Account();
           // account.AccountNumber = 233222;
           // account.BranchNumberNavigation = context.Branches.Find(125);

           // card.Account = account;

           // context.AddRange(client,card,account);
           // context.SaveChanges(); 

           //// End:;
           // }
            */
        }

        private static void Main2()
        {
           
        }
    }
    
}
