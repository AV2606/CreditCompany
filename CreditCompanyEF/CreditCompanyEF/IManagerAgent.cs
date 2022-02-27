using CreditCompanyEF.Models;

namespace CreditCompanyEF
{
    public interface IManagerAgent:IAgent
    {
        public Manager Manager { get; }
    }
}