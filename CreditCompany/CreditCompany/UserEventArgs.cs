using CreditCompanyEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCompany
{
    /// <summary>
    /// An event args that holds the relevant information about the user.
    /// </summary>
    public class UserEventArgs : EventArgs
    {
        public ClientAgent ClientAgent { get; set; }
        public ManagerAgent ManagerAgent { get; set; }

        public UserEventArgs(ManagerAgent managerAgent, ClientAgent clientAgent)
        {
            this.ClientAgent = clientAgent;
            this.ManagerAgent = managerAgent;
        }
        /// <summary>
        /// Indicates whether the user includes a manager agent or not.
        /// </summary>
        /// <returns>true if the user is a manager, false otherwise.</returns>
        public bool IncludesManager() => ManagerAgent is not null;
        /// <summary>
        /// Indicates whether the user includes a client agent or not.
        /// </summary>
        /// <returns>true if the user is a client, false otherwise.</returns>
        public bool IncludesClient() => ClientAgent is not null;
    }

}
