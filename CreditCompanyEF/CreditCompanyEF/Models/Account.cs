using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Account
    {
        public Account()
        {
            ClientsAccounts = new HashSet<ClientsAccount>();
            CreditCards = new HashSet<CreditCard>();
        }

        public int UniqueAccountId { get; set; }
        public int? AccountNumber { get; set; }
        public int? BranchNumber { get; set; }

        public virtual Branch BranchNumberNavigation { get; set; }
        public virtual ICollection<ClientsAccount> ClientsAccounts { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
    }
}
