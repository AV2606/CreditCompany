using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Accounts = new HashSet<Account>();
        }

        public int BranchNumber { get; set; }
        public int? BankNumber { get; set; }
        public string BranchName { get; set; }

        public virtual Bank BankNumberNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
