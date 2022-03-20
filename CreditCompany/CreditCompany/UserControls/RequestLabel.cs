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
    internal class RequestLabel : Label
    {
        public RequestsFromClient request;

        public RequestLabel() : base() { }
    }
}
