using CreditCompanyEF.Exceptions;
using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreditCompanyEF
{
    public enum Banks
    {
        Hapoalim=12,
        Leumi=10,
        Discount=11,
        Yahav=04,
        MizrahiTfahot=20,
        Habenleumi=31,
        MarcentilDiscount=17,
        Massad=46,
        OtsarHahyal=14,
        PostBank=9,
        UBank=26,
        Union=13,
    }
    /// <summary>
    /// Holds the result of creating a transaction.
    /// </summary>
    public enum TransactionResult
    {
        Succefull=1,
        UnKnownFailure=0,
        CardIsCanceled=-1,
        NotEnoughCredit=-2,
        CardIsRecievingOnly=-3,
    }

    /// <summary>
    /// An agent handeling the <see cref="manager"/>.
    /// </summary>
    public class ManagerAgent:IDisposable,IAsyncDisposable,IManagerAgent
    {
        //static CreditCompanyContext staticContext = new CreditCompanyContext();


        protected CreditCompanyContext context = new CreditCompanyContext();
        private Manager manager;
        /// <summary>
        /// The inner manager user.
        /// </summary>
        public Manager Manager => manager;
        private Random rnd = new Random();
        /// <summary>
        /// The client for the current usage.
        /// </summary>
        internal Client innerClient;

        /// <summary>
        /// The client that represents that the client data of the entity has been removed.
        /// </summary>
        static readonly Client nullClient;
        /// <summary>
        /// The card of the nullCard.
        /// </summary>
        static readonly Models.CreditCard nullCard;

        static List<ManagerAgent> managers = new List<ManagerAgent>();

        public void Dispose()
        {
            context.Dispose();
        }
        public ValueTask DisposeAsync()
        {
            return context.DisposeAsync();
        }

        static ManagerAgent()
        {
            nullClient = IAgent.staticContext.Clients.Find(-1);
            IAgent.staticContext.Entry(nullClient).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            nullCard = IAgent.staticContext.CreditCards.Find("0000111122223333");
            IAgent.staticContext.Entry(nullCard).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public ManagerAgent()
        {
            managers.Add(this);
        }

        ~ManagerAgent()
        {
            DisposeAsync();
        }
        /// <summary>
        /// Retrieves the date which the client and the company first got in business.
        /// </summary>
        /// <param name="clientAgent"></param>
        /// <returns>The start date, or <see cref="DateTime.MinValue"/> if something went wrong.</returns>
        public DateTime GetStartDate(ClientAgent clientAgent)
        {
            clientAgent.Client.AssignClient(this);
            return innerClient.AssignDate is null?  DateTime.MinValue: (DateTime)innerClient.AssignDate;
        }
        /// <summary>
        /// Returns <paramref name="proxies"/> as a list of the originals <see cref="Models.CreditCard"/>
        /// </summary>
        /// <param name="proxies">The proxies to unproxify</param>
        /// <returns></returns>
        public List<Models.CreditCard> ToCreditCardList(IEnumerable<Proxies.CreditCardClientProxy> proxies)
        {
            List<Models.CreditCard> r = new List<Models.CreditCard>();
            foreach (var item in proxies)
            {
                r.Add(item.creditCard);
            }
            return r;
        }
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="AddToContext"></param>
        /// <returns></returns>
        public User AddUser(string userName, string password,bool AddToContext=false)
        {
            User user = new User();
            user.UserName = userName;
            user.UserPassword = password;
            if (AddToContext)
                context.Add(user);
            return user;
        }

        /// <summary>
        /// Cancels the <paramref name="card"/>
        /// </summary>
        /// <param name="card"></param>
        public void CancelCard(Proxies.CreditCardClientProxy card)
        {
            card.creditCard.IsCanceled = true;
            var entry = context.Entry(card.creditCard);
            if (entry.State != Microsoft.EntityFrameworkCore.EntityState.Modified)
                entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //card.creditCard
            SaveChanges();
        }

        /// <summary>
        /// Retrieves the credit score of the client by its agent.
        /// </summary>
        /// <param name="clientAgent"></param>
        /// <returns>The credit score, or 0 if something went wrong.</returns>
        public int GetCreditScore(ClientAgent clientAgent)
        {
            clientAgent.Client.AssignClient(this);
            if (innerClient.CreditScore is null)
                return 0;
            return (int)innerClient.CreditScore;
           // return client.CreditScore is null ? (int)client.CreditScore: 0;
        }
        /// <summary>
        /// Get the manager assosiated with the <paramref name="userName"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="userName">The user name of the manager.</param>
        /// <param name="password">The password of the manager.</param>
        /// <returns></returns>
        public static ManagerAgent GetManager(string userName, string password)
        {
            List<User> users;// = GetUsers(userName, password);
            if (IsUserExists(userName, password, out users)==false)
                return null;
            // throw new ManagerDoesNotFound("Cant find any manager with the user name or password.");
            //var usersList = users.ToList();
            //if(users.Count<1)
            //  throw new ManagerDoesNotFound("Cant find any manager with the user name or password.");
            if (users[0].IfManager is null)
                return null;
            //throw new ManagerDoesntFoundException("The user does not related to any manager.");
            ManagerAgent r = new ManagerAgent();
            r.manager = users[0].IfManager;
            return r;
        }

        /// <summary>
        /// Marks the <see cref="RequestsFromClient"/> of <paramref name="respondRequest"/> as seen and answered.
        /// </summary>
        /// <param name="respondRequest"></param>
        public void MarkAsAnswered(RequestsFromClient respondRequest)
        {
            respondRequest.Answered = true;
            respondRequest.HasBeenViewd = true;
            SaveChanges();
        }

        /// <summary>
        /// Makes the <paramref name="card"/> recieving only.
        /// </summary>
        /// <param name="card"></param>
        public void HoldCard(Proxies.CreditCardClientProxy card)
        {
            card.creditCard.IsRecievingOnly = true;
            var entry = context.Entry(card.creditCard);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            SaveChanges();
        }
        /// <summary>
        /// Retrieves the client from the agent.
        /// </summary>
        /// <param name="clientAgent"></param>
        /// <returns></returns>
        public Client GetClientByAgent(ClientAgent clientAgent)
        {
            clientAgent.Client.AssignClient(this);
            return innerClient;
        }

        /// <summary>
        /// Saves all the changes made by the manager.
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        /// <summary>
        /// Checks if a user is existing in the data base.
        /// </summary>
        /// <param name="userName">The user name to look for.</param>
        /// <returns></returns>
        public bool IsUserNameExists(string userName)
        {
            var users = from u in context.Users
                        where u.UserName == userName
                        select u;
            if (users.Count() > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Adds a new client and add it and all of its related data to the database.
        /// </summary>
        /// <param name="creditScore">The credit score of the client.</param>
        /// <param name="firstName">The client's first name.</param>
        /// <param name="lastName">The client's las name.</param>
        /// <param name="creditCards">A list of credit cards that would be owned by the cient.</param>
        /// <param name="user">A user for the new client.</param>
        /// <returns>Returns the client that has been created.</returns>
        public async Task<Client> AddClientAsync(int creditScore,string firstName, string lastName,IEnumerable<Models.CreditCard> creditCards, User user)
        {
            //throw new NotImplementedException();
            if (IsUserNameExists(user.UserName))
                throw new UserAlreadyExistsException("A user with the same user name already exists.");
            if (creditCards.Count() == 0)
                throw new InavlidArgumentsException("The client cant have no credit cards.");
            Client c = new Client();
            //Assign the client to the credit cards.
            foreach (var cd in creditCards)
            {
                cd.Client = c;
                context.Add(cd);
            }
            c.FirstName = firstName;
            c.LastName = lastName;
            c.CreditScore = creditScore;
            user.IfClient = c;
            context.AddRange(user,c);

            Account[] GetDistinctAccounts(IEnumerable<Models.CreditCard> cards)
            {
                var r = new List<Account>();
                foreach (var c in cards)
                {
                    if (r.FindAll((a) => { return a == c.Account; }).Count == 0)
                        r.Add(c.Account);
                }
                return r.ToArray();
            }

            var clientsAccounts = new List<ClientsAccount>();

            foreach (var a in GetDistinctAccounts(creditCards))
            {
                ClientsAccount cAs = new ClientsAccount();
                cAs.Account = a;
                cAs.Client = c;
                clientsAccounts.Add(cAs);
            }

            context.AddRange(clientsAccounts);

            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                context.RemoveRange(c, creditCards, user,clientsAccounts);
                throw;
            }
            return c;
        }
       /// <summary>
       /// Wipes out all the data related to the client, this operation cannot been undone.
       /// </summary>
       /// <param name="c">The client's entiy</param>
        public void WipeClient(Client c)
        {
            if (context.Entry(c).State==Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                RemoveAllRelatedTablesByObjects(c);
            }
            else if (context.Entry(c).State == Microsoft.EntityFrameworkCore.EntityState.Unchanged)
            {
                RemoveAllRelatedTablesById(c.ClientId);
            }
            SaveChanges();
        }
        /// <summary>
        /// Adds a new credit card.
        /// </summary>
        /// <param name="credit">The total approved credit for the card.</param>
        /// <param name="club">The name of the members club of the card.</param>
        /// <param name="account">The account of the credit card.</param>
        /// <param name="addToContext">indicates whether to add the card to the database context or not, false by default.</param>
        /// <returns>Returns the credit card (raw value, with no database context).</returns>
        public Models.CreditCard AddCreditCard(double credit,Account account, string club="Default", bool addToContext=false)
        {
            //throw new NotImplementedException();
            Models.CreditCard c = new Models.CreditCard();
            c.CreditCardNumber = GetRandomCardNumber();
            c.Credit=credit;
            c.UsedCredit = 0;
            c.IsCanceled = false;
            c.IsRecievingOnly = false;
            c.Club = club;
            if (account.UniqueAccountId==0)
                c.Account = account;
            else
                c.AccountId = account.UniqueAccountId;
            if (addToContext)
                context.Add(c);
            return c;
        }
        /// <summary>
        /// Gives a RNG generated account.
        /// </summary>
        /// <param name="addToContext">Indicates whether the account will be added to the context or not, (false by default).</param>
        /// <returns>Returns the account. (raw value, with no database context)</returns>
        public Account GetRandomAccount(bool addToContext=false)
        {
            Account account = new Account();
            account.AccountNumber = rnd.Next(999999);
            var branches = GetAllBranches();
            account.BranchNumberNavigation = branches[rnd.Next(branches.Count)];
            if (IsAccountExists(account))
                return GetRandomAccount();
            if (addToContext)
                context.Add(account);
            return account;
        }
        /// <summary>
        /// Generate an account and checks if it already exists. (should not be added directly to the databse.)
        /// </summary>
        /// <param name="number">The number of the account.</param>
        /// <param name="branch">The branch of the account.</param>
        /// <returns>Returns the new account, if the account cant be generated returns null.</returns>
        public Account GenerateAccount(int number, int branch)
        {
            var aList = from a in context.Accounts
                        where a.AccountNumber == number && a.BranchNumber == a.BranchNumber
                        select a;
            if (aList.ToList().Count > 0)
                return null;
            Account a1 = new Account();
            a1.AccountNumber = number;
            a1.BranchNumber = branch;
            return a1;
        }
        /// <summary>
        /// Gives all the known branches of the bank.
        /// </summary>
        /// <param name="bank">The bank that owns the branch.</param>
        /// <returns></returns>
        public List<int> GetAllBranches(Banks bank)
        {
            int bankNumber = ((int)bank);
            var branches = from b in context.Branches
                           where b.BankNumber == bankNumber
                           select b.BranchNumber;
            return branches.ToList();
        }
        /// <summary>
        /// Gives all the known branches of the bank.
        /// </summary>
        /// <param name="bank">The bank that owns the branch.</param>
        /// <returns></returns>
        public List<Branch> GetAllBranchesModels(Banks bank)
        {
            int bankNumber = ((int)bank);
            var branches = from b in context.Branches
                           where b.BankNumber == bankNumber
                           select b;
            return branches.ToList();
        }
        /// <summary>
        /// Tries to add a new manager to the company. (if the user already has manager use <see cref="AlterManager"/> instead.)
        /// </summary>
        /// <param name="user">The user for the manager.</param>
        /// <param name="manager">The manager.</param>
        /// <returns>returns true if the manager is added succefully, false otherwise.</returns>
        public bool AddManager(User user, Manager manager)
        {
            if (user.IfManager is not null)
                return false;
            user.IfManager = manager;
            try
            {
                context.Add(user);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Changes the manager of the user that already exists in the database. then removes it.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="manager">The new manager.</param>
        /// <returns>Returns the removed manager, returns null if there was no manager to remove or if the operation was not succesfull.</returns>
        public Manager AlterManager(int userId, Manager manager)
        {
            var user = context.Users.Find(userId);
            if (user is null)
                return null;
            Manager r=null;
            if (user.IfManager is not null)
            {
                context.Remove(user.IfManager);
                r = user.IfManager;
            }
            user.IfManager = manager;
            return r;
        }
        /// <summary>
        /// Adds a new message for the client.
        /// </summary>
        /// <param name="title">The title of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="reciever">The client that should recieve the message.</param>
        /// <returns>Returns true if the message has been sent succefully, false otherwise.</returns>
        public bool AddMesasge(string title,string content,Client reciever)
        {
            Message message = new Message();
            if (reciever.ClientId != 0)
                message.ClientRecieverId = reciever.ClientId;
            else
                message.ClientReciever = reciever;
            message.IsViewed = false;
            message.ManagerSenderId = manager.ManagerId;
            message.MessageContent =content;
            message.MessageTitle =title;
            try
            {
                context.Add(message);
                SaveChanges();
            }
            catch(Exception e)
            {
                context.Remove(message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Adds a new message for the client.
        /// </summary>
        /// <param name="title">The title of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="reciever">The client that should recieve the message.</param>
        /// <returns>Returns true if the message has been sent succefully, false otherwise.</returns>
        public bool AddMesasge(string title, string content, ClientDataProxy reciever)
        {
            reciever.AssignClient(this);
            return AddMesasge(title, content, innerClient);
        }
        /// <summary>
        /// Adds a new message for the client.
        /// </summary>
        /// <param name="title">The title of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="recieverCard">The card of the client that should recieve the message.</param>
        /// <returns>Returns true if the message has been sent succefully, false otherwise.</returns>
        public bool AddMesasge(string title, string content, Proxies.CreditCardClientProxy recieverCard)
        {
            return AddMesasge(title, content, recieverCard.creditCard.Client);
        }
        /// <summary>
        /// Adds a new transaction.
        /// </summary>
        /// <param name="payment">The payment that the business asks for.</param>
        /// <param name="card">The card that pays</param>
        /// <param name="reciever">The client that recieves the payment.</param>
        /// <param name="businessName">The name of the business.</param>
        /// <param name="cardShowed">Indicatess whether the card has been showed or not.</param>
        /// <returns>The result of the transaction.</returns>
        public TransactionResult AddTransaction(double payment, Models.CreditCard card,Client reciever, string businessName, bool cardShowed=true)
        {
            if (card.IsCanceled)
                return TransactionResult.CardIsCanceled;
            if (card.IsRecievingOnly)
                return TransactionResult.CardIsRecievingOnly;
            if(card.Credit!=-1)
                if (payment + card.UsedCredit > card.Credit)
                    return TransactionResult.NotEnoughCredit;
            Transaction transaction = new Transaction();
            transaction.Date = DateTime.Now;
            transaction.Business =businessName;
            transaction.CardShowed =cardShowed;
            transaction.PayerCardNumber = card.CreditCardNumber;
            //transaction.PayerCardNumberNavigation =card;
            transaction.Payment = payment;
            transaction.ReciverClientId =reciever.ClientId;
            context.Add(transaction);
            try
            {
                card.UsedCredit += payment;
                SaveChanges();
            }
            catch(Exception e)
            {
                context.Remove(transaction);
                card.UsedCredit -= payment;
                return TransactionResult.UnKnownFailure;
            }
            return TransactionResult.Succefull;
        }

        /// <summary>
        /// Find the client by its id.
        /// </summary>
        /// <param name="id">The id of the client.</param>
        /// <returns>The client if exists, returns null if not.</returns>
        public Client GetClientById(int id)
        {
            var r=context.Clients.Find(id);
            return r;
        }
        
        //Checks if a user is existing in the data base, and return a list of users that satisfy the username and password.
        protected static bool IsUserExists(string userName, string password, out List<User> userList)
        {
            lock (IAgent.staticContext)
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
            lock (IAgent.staticContext)
            {
                return from u in IAgent.staticContext.Users
                       where u.UserName == userName && u.UserPassword == password
                       select u;
            }
        }
        //Removes all the data from the client by its id.
        private void RemoveAllRelatedTablesById(int id)
        {
            //Assign nullClient to all credit cards.
            var creditCards = from card in context.CreditCards
                              where card.ClientId == id
                              select card;
            foreach (var item in creditCards)
            {
                item.Client = nullClient;
            }

            //Remove every connection from a bank account to the client.
            var clientsAccounts = from ca in context.ClientsAccounts
                                  where ca.ClientId==id//object.ReferenceEquals(ca.Client, c)
                                  select ca;
            context.RemoveRange(clientsAccounts);

            //Assign nullClient to all transactions.
            var transactions = from t in context.Transactions
                               where t.ReciverClientId==id//object.ReferenceEquals(t.ReciverClient, c)
                               select t;
            foreach (var item in transactions)
            {
                item.ReciverClient = nullClient;
            }

            //Remove all the requests from the client from the database.
            var requestsFromClient = from rfc in context.RequestsFromClients
                                     where rfc.ClientId==id//object.ReferenceEquals(rfc.Client, c)
                                     select rfc;
            context.RemoveRange(requestsFromClient);

            //Remove users if they contain only the client, if the user is also related to a manager - assign the client to be null.
            var users = from u in context.Users
                        where u.IfClientId==id//object.ReferenceEquals(u.IfClient, c)
                        select u;
            foreach (var item in users)
            {
                if (item.IfManager is null)
                    context.Remove(item);
                else
                    item.IfClient = nullClient;
            }
            //Assign nullClient to all messages.
            var messages = from m in context.Messages
                           where m.ClientRecieverId==id//object.ReferenceEquals(m.ClientReciever, c)
                           select m;
            foreach (var item in messages)
            {
                item.ClientReciever = nullClient;
            }
        }
        //Removes all the data from the client by the entity.
        private void RemoveAllRelatedTablesByObjects(Client c)
        {
            //Assign nullClient to all credit cards.
            var creditCards = from card in context.CreditCards
                              where object.ReferenceEquals(c, card.Client)
                              select card;
            foreach (var item in creditCards)
            {
                item.Client = nullClient;
            }

            //Remove every connection from a bank account to the client.
            var clientsAccounts = from ca in context.ClientsAccounts
                                  where object.ReferenceEquals(ca.Client, c)
                                  select ca;
            context.RemoveRange(clientsAccounts);

            //Assign nullClient to all transactions.
            var transactions = from t in context.Transactions
                               where object.ReferenceEquals(t.ReciverClient, c)
                               select t;
            foreach (var item in transactions)
            {
                item.ReciverClient = nullClient;
            }

            //Remove all the requests from the client from the database.
            var requestsFromClient = from rfc in context.RequestsFromClients
                                     where object.ReferenceEquals(rfc.Client, c)
                                     select rfc;
            context.RemoveRange(requestsFromClient);

            //Remove users if they contain only the client, if the user is also related to a manager - assign the client to be null.
            var users = from u in context.Users
                        where object.ReferenceEquals(u.IfClient, c)
                        select u;
            foreach (var item in users)
            {
                if (item.IfManager is null)
                    context.Remove(item);
                else
                    item.IfClient = nullClient;
            }
            //Assign nullClient to all messages.
            var messages = from m in context.Messages
                           where object.ReferenceEquals(m.ClientReciever, c)
                           select m;
            foreach (var item in messages)
            {
                item.ClientReciever = nullClient;
            }
        }
        /// <summary>
        /// Give a random 16-digit number formated as a string.
        /// </summary>
        /// <returns></returns>
        private string GetRandomCardNumber()
        {
            string r = rnd.Next(1, 9) + "";
            for (int i = 0; i < 15; i++)
            {
                r += rnd.Next(0, 9);
            }
            return r;
        }
        private bool IsAccountExists(Account ac)
        {
            var acs = from a in context.Accounts
                      where a.AccountNumber == ac.AccountNumber && a.BranchNumberNavigation == ac.BranchNumberNavigation
                      select a;
            if (acs.ToList().Count > 0)
                return true;
            return false;
        }
        private List<Branch> GetAllBranches()
        {
            var bnchs = from b in context.Branches
                        select b;
            return bnchs.ToList();
        }
        /// <summary>
        /// Returns all the requests that has not been answered.
        /// </summary>
        /// <param name="clientId">If given as parameter- indicates that the function should filter only the specific client.</param>
        /// <param name="title">If given as parameter- indicates that the function should filter the requests to has this exact title.</param>
        /// <returns></returns>
        public List<RequestsFromClient> GetRequestsFromClients(int clientId=-2,string title = "0x")
        {
            var rfc = context.RequestsFromClients;
            IQueryable<RequestsFromClient> query=rfc.Where(r=>r.Answered==false);
            if (clientId != -2)
                query = query.Where(r => r.ClientId == clientId);
            if (title != "0x")
                query = query.Where(r => r.Title == title);
            query = from r in query
                    orderby r.Date descending
                    select r;
            return query.ToList();
        }
        /// <summary>
        /// Detahcs the entity from the context.
        /// </summary>
        /// <param name="account"></param>
        public void Detach(object entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
        /// <summary>
        /// Attach the client to the credit card and to the managerAgent.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="clientAgent"></param>
        public void AttachClient(Models.CreditCard c, ClientAgent clientAgent)
        {
            clientAgent.Client.AssignClient(this);
            c.ClientId = innerClient.ClientId;
        }
        /// <summary>
        /// Attach the client to the credit card but not to the managerAgent (other overloads
        /// might attach to the managerAgent as well)
        /// </summary>
        /// <param name="c"></param>
        /// <param name="client"></param>
        public void AttachClient(Models.CreditCard c, Client client)
        {
            c.ClientId = client.ClientId;
        }
        /// <summary>
        /// Refund the money to the client.
        /// </summary>
        /// <param name="transaction">The transaction to cancel.</param>
        public void RefundTransaction(Transaction transaction)
        {
            transaction.IsDenied = true;
            if (transaction.TransactionId == 0)
                context.Add(transaction);
            else
                context.Entry(transaction).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result=AddTransaction((double)transaction.Payment, nullCard, transaction.ReciverClient, "Credit Company", false);
            if (result == TransactionResult.UnKnownFailure)
                throw new Exception("What happend???");
        }
        /// <summary>
        /// Refund the money to the client.
        /// </summary>
        /// <param name="transaction">The transaction to cancel.</param>
        public void RefundTransaction(TransactionClientProxy transaction)
        {
            RefundTransaction(transaction.GetTransaction());
        }
        /// <summary>
        /// Retrieves the actual transaction.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Transaction GetTransaction(TransactionClientProxy transaction)
        {
            return transaction.GetTransaction();
        }
        /// <summary>
        /// Returns all the credit cards that can pay and owned by clients.
        /// </summary>
        /// <returns></returns>
        public List<CreditCard> GetAllPayersCards()
        {
            return context.CreditCards.Where(IsCardPayer).ToList();
        }
        /// <summary>
        /// Checks if the card is a valid card that can do payments.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsCardPayer(CreditCard c) 
        {
            return c is not null&&c.IsRecievingOnly == false && c.CreditCardNumber != nullCard.CreditCardNumber && c.IsCanceled == false;
        }
        /// <summary>
        /// Returns all the clients that has payer credit card.
        /// </summary>
        /// <returns></returns>
        public List<Client> GetAllPayerClients()
        {
            IEnumerable<Client> Helper()
            {
                var query1 = GetAllPayersCards();
                foreach (var item in query1)
                {
                    if(item is not null&&item.Client is not null)
                    yield return item.Client;
                }
            }
            return Helper().Distinct().ToList();
        }
        /// <summary>
        /// Returns all the known buisnesses that recieved payments from the company.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKnownBusinesses()
        {
            var query = from t in context.Transactions
                        where t.Business!=""&&t.Business!=null
                        select t.Business;
            var query1 = query.Distinct();
            return query1.ToList();
        }
    }
}
