using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCompanyEF.Models;
using System.Text.Json;
using CreditCompanyEF.Proxies.Extensions;
using CreditCompanyEF.Proxies;

namespace CreditCompanyEF.Proxies
{
    /// <summary>
    /// Provides all the data that should be accessed by the clients.
    /// </summary>
    public class ClientDataProxy:IProxy
    {
        #region InstanceMembers
        /// <summary>
        /// The raw client EF object
        /// </summary>
        protected Client ClientData { get;}
        /// <summary>
        /// the client's id
        /// </summary>
        protected int Id => ClientData.ClientId;


        //The raw list of creditCards, here for simplicity
        private List<Models.CreditCard> creditCards;
        /// <summary>
        /// All the credit cards of the client proxied to provide un authorized data access and changes.
        /// </summary>
        public IReadOnlyList<CreditCardClientProxy> CreditCards => creditCards.ToProxyList();
        /// <summary>
        /// All the cards that client can use.
        /// </summary>
        public IReadOnlyList<CreditCardClientProxy> WorkingCards => CreditCards.Where(c => c.IsCanceled==false&&c.IsRecievingOnly==false).ToList();
        /// <summary>
        /// Client's first name
        /// </summary>
        public string FirstName { get => ClientData.FirstName;
            set
            {
                ClientData.FirstName = value;
            }
        }
        /// <summary>
        /// Client's last name
        /// </summary>
        public string LastName
        {
            get => ClientData.LastName;
            set
            {
                ClientData.LastName = value;
            }
        }
        /// <summary>
        /// All the transactions of the client proxied to provide un authorized data access and changes.
        /// </summary>
        public IReadOnlyList<TransactionClientProxy> Transactions => ClientData.Transactions.ToProxyList();
        /// <summary>
        /// The total credit the client has been given by the company.
        /// </summary>
        public double TotalCredit => GetTotalCredit();
        /// <summary>
        /// All the credit that the client used by all of his credit cards.
        /// </summary>
        public double UsedCredit => GetUsedCredit();
        /// <summary>
        /// All the messages the client got from the company proxied to provide un authorized data access and changes.
        /// </summary>
        public IReadOnlyList<MessageClientProxy> MessagesFromCompany => ClientData.Messages.ToProxyList();


        private ClientDataProxy(User user)
        {
            this.ClientData = user.IfClient;
            creditCards = ClientData.CreditCards.ToList();
            AddToTracking(this);
        }
        private ClientDataProxy(Client client)
        {
            this.ClientData = client;
            creditCards = ClientData.CreditCards.ToList();
            AddToTracking(this);
        }
        ~ClientDataProxy() => Dispose();
        /// <summary>
        /// Adds <paramref name="self"/> to the list of tracked proxies.
        /// </summary>
        /// <param name="self">The <see cref="ClientDataProxy"/> to begin tracking.</param>
        private void AddToTracking(ClientDataProxy self)
        {
            if (ClientDataProxy.proxies.Find(self) is null)
                proxies.Add(self);
        }

        public void Dispose()
        {
            proxies.Remove(this);
        }
        /// <summary>
        /// Assigns the client from this proxy to the manager's slot.
        /// </summary>
        /// <param name="manager"></param>
        public void AssignClient(ManagerAgent manager)
        {
            manager.innerClient = ClientData;
        }
        private double GetTotalCredit()
        {
            double r = 0;
            foreach (var card in creditCards)
            {
                if (card.Credit is not null)
                    r += (double)card.Credit;
            }
            return r;
        }
        private double GetUsedCredit()
        {
            double r = 0;
            foreach (var card  in creditCards)
            {
                if (card.UsedCredit is not null)
                    r += (double)card.UsedCredit;
            }
            return r;
        }
        #endregion
        #region StaticMembers

        private static List<ClientDataProxy> proxies = new List<ClientDataProxy>();

        internal static ClientDataProxy GetProxy(User user)
        {
            return new ClientDataProxy(user);
        }
        public static ClientDataProxy GetProxy(Client client)
        {
            var proxy = proxies.Find((p) => { return p.Id == client.ClientId; });
            if (proxy is not null)
                return proxy;
            return new ClientDataProxy(client);
        }

        //public static ClientDataProxy GetClient(ClientDataProxy client)
        //{
        //    var proxy = proxies.Find(client);
        //    if (proxy is null)
        //        return new ClientDataProxy(client);
        //    return proxy;
        //}
        #endregion
    }
}
