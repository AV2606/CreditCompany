using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreditCompany.UserControls
{
    public class TransactionLabel:System.Windows.Forms.Label
    {

        public TransactionClientProxy transaction;
        public TransactionLabel() : base() { }
    }
}
