using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public string PayerCardNumber { get; set; }
        public int? ReciverClientId { get; set; }
        public double? Payment { get; set; }
        public DateTime? Date { get; set; }
        public bool? CardShowed { get; set; }
        public string Business { get; set; }
        public bool? IsDenied { get; set; }
        public int? DenyRequestId { get; set; }

        public virtual RequestsFromClient DenyRequest { get; set; }
        public virtual CreditCard PayerCardNumberNavigation { get; set; }
        public virtual Client ReciverClient { get; set; }
    }
}
