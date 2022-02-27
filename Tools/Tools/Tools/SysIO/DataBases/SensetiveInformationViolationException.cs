using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.SysIO
{
    /// <summary>
    /// Occures when a <see cref="SensetiveDataBase{T}"/> sensetivity has been violated in any case.
    /// </summary>
    public class SensetiveInformationViolationException : Exception
    {
        public SensetiveInformationViolationException(string message) : base(message)
        {
        }
    }
}
