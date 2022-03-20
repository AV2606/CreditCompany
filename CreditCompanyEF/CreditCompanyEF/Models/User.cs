using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool? IsManager { get; set; }
        public int? IfManagerId { get; set; }
        public int? IfClientId { get; set; }

        public virtual Client IfClient { get; set; }
        public virtual Manager IfManager { get; set; }
    }
}
