using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Branches = new HashSet<Branch>();
        }

        public int BankNumber { get; set; }
        public string BankName { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
