using System;
using System.Collections.Generic;

#nullable disable

namespace CreditCompanyEF.Models
{
    public partial class ClientsInfo
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public int? CreditScore { get; set; }
        public string MainCardLastDigits { get; set; }
        public int? NumberOfCards { get; set; }
        public double? TotalUsedCredit { get; set; }
        public double? TotalCredit { get; set; }
    }
}
