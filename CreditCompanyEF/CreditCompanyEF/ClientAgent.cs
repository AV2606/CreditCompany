using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCompanyEF.Proxies;
using CreditCompanyEF.Models;
using CreditCompanyEF.Exceptions;
using CreditCompanyEF.Proxies.Extensions;

namespace CreditCompanyEF
{
    /// <summary>
    /// Includes a set of titles for client requests.
    /// </summary>
    public enum RequestsTitles
    {
        BlockCreditCardRequest=0,
        IssueNewCreditCardRequest,
        CancelCreditCardRequest,
        DenyTransactionRequest,
    }
    /// <summary>
    /// An agent to handle the <see cref="ClientDataProxy"/>.
    /// </summary>
    public class ClientAgent : IClientAgent
    {
        public static string[] _titles = new string[] { 
            "*Immidiate* Block Credit Card.",
            "Issue New Card Request.",
            "*Immidiate* Cancel Credit Card.",
            "Denial of transaction."
        };

        //static CreditCompanyContext staticContext = new CreditCompanyContext();

        protected CreditCompanyContext context = new CreditCompanyContext();


        private Client client;

        /// <summary>
        /// Retrievs the client's proxy from the agent.
        /// </summary>
        public ClientDataProxy Client => client.ToClientProxy();

        public void Dispose()
        {
            if (context is not null)
            {
                context.Dispose();
            }
        }
        public ValueTask DisposeAsync()
        {
            return context.DisposeAsync();
        }


        /// <summary>
        /// Gives the client agent assosiated with the <paramref name="userName"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="userName">The user name of the client.</param>
        /// <param name="password">The password of the client.</param>
        /// <returns></returns>
        public static ClientAgent GetClient(string userName, string password)
        {
            List<User> users;// = GetUsers(userName, password);
            if (IsUserExists(userName, password, out users)==false)
                return null;
            if (users.ElementAt(0).IfClient is null)
                return null;
            ClientAgent r = new ClientAgent();
            r.client = users[0].IfClient;
            return r;
        }
        /// <summary>
        /// Marks <paramref name="message"/> as viewed.
        /// </summary>
        /// <param name="message">The message you just read.</param>
        public void ViewMessage(MessageClientProxy message)
        {
            message.MarkAsRead(this.client);
        }

        /// <summary>
        /// Gets All the relevant transactions of the client between the specified dates.
        /// </summary>
        /// <param name="startDate">The date and time to start look at.</param>
        /// <param name="endDate">The date and time to stop look at.</param>
        /// <returns></returns>
        public List<TransactionClientProxy> GetTransactionsByDates(DateTime startDate, DateTime endDate)
        {
            var ts = from t in context.Transactions
                     where t.Date > startDate&& t.Date < endDate &&t.PayerCardNumberNavigation.Client==client
                     select t;
            //var ts = context.Transactions.Where((t) => GetTransactionsByDatesPredicate(t,startDate,endDate)) ;
            var r0 = ts.ToList();
            return r0.ToProxyList();
        }

        private bool GetTransactionsByDatesPredicate(Transaction t, DateTime startDate, DateTime endDate)
        {
            return t.Date - startDate > TimeSpan.Zero && t.Date - endDate < TimeSpan.Zero && t.PayerCardNumberNavigation.Client == client;
        }

        /// <summary>
        /// Sends a request from the client to the company
        /// </summary>
        /// <param name="title">The title of the request, given from the common titles.</param>
        /// <param name="content">The content of the request.</param>
        /// <returns>true if the request sent succesfully, false otherwise.</returns>
        public RequestsFromClient SendRequest(RequestsTitles title, string content)
        {
            return SendRequest(_titles[((int)title)], content);
        }
        /// <summary>
        /// Sends a request from the client to the company
        /// </summary>
        /// <param name="title">The title of the request.</param>
        /// <param name="content">The content of the request.</param>
        /// <returns>The request or null if the method failed.</returns>
        public RequestsFromClient SendRequest(string title, string content)
        {
            RequestsFromClient msg = new RequestsFromClient();
            try
            {
                msg.Answered = false;
                //msg.Client = client;
                msg.ClientId = client.ClientId;
                msg.Content = content;
                msg.HasBeenViewd = false;
                msg.Title = title;
                msg.Date = DateTime.Now;
                context.RequestsFromClients.Add(msg);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                return null;
            }
            return msg;
        }
        /// <summary>
        /// Gets All the accounts of the client.
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAccounts()
        {
            return (from a in context.ClientsAccounts
                    where a.Client == client
                    select a.Account
                    ).ToList();
        }
        /// <summary>
        /// Marks the <paramref name="transaction"/> as denied by the client and attch the <paramref name="request"/>
        /// as the deny request.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="request"></param>
        public void DenyTransactionAsync(TransactionClientProxy transaction, RequestsFromClient request)
        {
            transaction.Deny(request);
            context.SaveChanges();
        }

        //Checks if a user is existing in the data base, and return a list of users that satisfy the username and password.
        protected static bool IsUserExists(string userName, string password, out List<User> userList)
        {
            lock (IAgent.staticContext.Users)
            {
                var users = GetUsers(userName, password);
                userList = null;
                if (users is null)
                    return false;
                userList = users.ToList();
                if (userList.Count == 0)
                    return false;
                return true;
            }
        }
        // Gets all the users with the username and password.       
        private static IQueryable<User> GetUsers(string userName, string password)
        {
            lock (IAgent.staticContext.Users)
            {
                return from u in IAgent.staticContext.Users
                       where u.UserName == userName && u.UserPassword == password
                       select u;
            }
        }

    }
}
