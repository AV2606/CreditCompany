using CreditCompanyEF.Models;
using System.Threading;

namespace CreditCompanyEF
{
    /// <summary>
    /// The base interface for the agents.
    /// </summary>
    public interface IAgent
    {
        protected static CreditCompanyContext staticContext = new CreditCompanyContext();
    }
}