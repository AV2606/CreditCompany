using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
using System;
using System.Collections.Generic;

namespace CreditCompanyEF
{
    public interface IClientAgent:IDisposable,IAsyncDisposable,IAgent
    {
        /// <summary>
        /// Returns the client off the <paramref name="userName"/> and <paramref name="password"/>
        /// </summary>
        /// <param name="userName">The user name of the client.</param>
        /// <param name="password">The password of the client.</param>
        /// <returns></returns>
       // ClientDataProxy GetClient(string userName, string password);
        // Manager GetManager(string userName, string password);
        //bool IsUserExists(string userName, string password, out List<User> userList);
        //void SaveChanges();
        public ClientDataProxy Client { get; }
    }
}