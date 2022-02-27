using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int? ManagerSenderId { get; set; }
        public int? ClientRecieverId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public bool? IsViewed { get; set; }

        public virtual Client ClientReciever { get; set; }
        public virtual Manager ManagerSender { get; set; }
    }
}
