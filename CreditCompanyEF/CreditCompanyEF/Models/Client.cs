using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientsAccounts = new HashSet<ClientsAccount>();
            CreditCards = new HashSet<CreditCard>();
            Messages = new HashSet<Message>();
            RequestsFromClients = new HashSet<RequestsFromClient>();
            Transactions = new HashSet<Transaction>();
            Users = new HashSet<User>();
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CreditScore { get; set; }
        public DateTime? AssignDate { get; set; }

        public virtual ICollection<ClientsAccount> ClientsAccounts { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<RequestsFromClient> RequestsFromClients { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
