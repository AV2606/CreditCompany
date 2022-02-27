using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string CreditCardNumber { get; set; }
        public int? ClientId { get; set; }
        public double? Credit { get; set; }
        public double? UsedCredit { get; set; }
        public bool IsCanceled { get; set; }
        public int? AccountId { get; set; }
        public bool IsRecievingOnly { get; set; }
        public string Club { get; set; }

        public virtual Account Account { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
