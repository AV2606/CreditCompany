using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class ClientsAccount
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Client Client { get; set; }
    }
}
