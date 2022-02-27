using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Manager
    {
        public Manager()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<User>();
        }

        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
