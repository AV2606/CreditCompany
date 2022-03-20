using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class RequestsFromClient
    {
        public RequestsFromClient()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int RequestId { get; 
            set; }
        public int? ClientId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool? HasBeenViewd { get; set; }
        public bool? Answered { get; set; }
        public DateTime? Date { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
