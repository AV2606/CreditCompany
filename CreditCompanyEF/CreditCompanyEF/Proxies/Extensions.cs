using CreditCompanyEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a set of extension methods for elements in <see cref="CreditCompanyEF.Proxies"/>.
/// </summary>
namespace CreditCompanyEF.Proxies.Extensions
{
    public static class Extensions
    {

        /// <summary>
        /// Invert the <see cref="IEnumerable{CreditCard}"/> <paramref name="cards"/> to <see cref="List{CreditCard}"/>
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static List<CreditCardClientProxy> ToProxyList(this IEnumerable<Models.CreditCard> cards)
        {
            List<CreditCardClientProxy> r = new List<CreditCardClientProxy>();
            foreach (var item in cards)
            {
                r.Add((CreditCardClientProxy)item);
            }
            return r;
        }
        /// <summary>
        /// Invert the <see cref="IEnumerable{T}"/> <paramref name="transactions"/> to <see cref="List{T}"/>
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public static List<TransactionClientProxy> ToProxyList(this IEnumerable<Transaction> transactions)
        {
            List<TransactionClientProxy> r = new List<TransactionClientProxy>();
            foreach (var item in transactions)
            {
                r.Add((TransactionClientProxy)item);
            }
            return r;
        }
        /// <summary>
        /// Invert the <see cref="IEnumerable{T}"/> <paramref name="messages"/> to <see cref="List{T}"/>
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static List<MessageClientProxy> ToProxyList(this IEnumerable<Message> messages)
        {
            List<MessageClientProxy> r = new List<MessageClientProxy>();
            foreach (var item in messages)
            {
                r.Add((MessageClientProxy)item);
            }
            return r;
        }
        /// <summary>
        /// Finds <paramref name="proxy"/> in <paramref name="proxies"/> and returns it, returns null otherwise.
        /// </summary>
        /// <param name="proxies">The collection of proxies.</param>
        /// <param name="proxy">the proxy to find.</param>
        /// <returns></returns>
        public static IProxy Find(this IEnumerable<IProxy> proxies, IProxy proxy)
        {
            foreach (var item in proxies)
            {
                if (object.ReferenceEquals(item, proxy))
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Returns a proxy of <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The client to proxify.</param>
        /// <returns></returns>
        public static ClientDataProxy ToClientProxy(this Client client)
        {
            return ClientDataProxy.GetProxy(client);
        }
        /// <summary>
        /// Returns a proxy of <paramref name="card"/>.
        /// </summary>
        /// <param name="card">The card to proxify.</param>
        /// <returns></returns>
        public static CreditCardClientProxy ToClientProxy(this Models.CreditCard card)
        {
            return CreditCardClientProxy.GetProxy(card);
        }
        /// <summary>
        /// Returns a proxy of <paramref name="msg"/>.
        /// </summary>
        /// <param name="msg">The message to proxify.</param>
        /// <returns></returns>
        public static MessageClientProxy ToClientProxy(this Message msg)
        {
            return MessageClientProxy.GetProxy(msg);
        }
        /// <summary>
        /// Returns a proxy of <paramref name="transaction"/>.
        /// </summary>
        /// <param name="transaction">The transaction to proxify.</param>
        /// <returns></returns>
        public static TransactionClientProxy ToClientProxy(this Transaction transaction)
        {
            return TransactionClientProxy.GetProxy(transaction);
        }
    }
}
