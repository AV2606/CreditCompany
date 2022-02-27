using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies.Extensions;
using System;
using System.Collections.Generic;

namespace CreditCompanyEF.Proxies
{
    /// <summary>
    /// A proxy handles the <see cref="Transaction"/> for the client.
    /// </summary>
    public class TransactionClientProxy : IProxy
    {
        #region InstanceMembers
        private Transaction transaction;
        /// <summary>
        /// The id of the transaction.
        /// </summary>
        public int TransactionId => transaction.TransactionId;
        /// <summary>
        /// The business that recieved the payment.
        /// </summary>
        public string Business => transaction.Business;
        /// <summary>
        /// Indicates whether the card has been physicly there when the transaction occures.
        /// </summary>
        public bool? CardShowed => transaction.CardShowed;
        /// <summary>
        /// The date at which the transaction occure.
        /// </summary>
        public DateTime? Date => transaction.Date;
        /// <summary>
        /// The number of the payer <see cref="Models.CreditCard"/>
        /// </summary>
        public string PayerCardNumber => transaction.PayerCardNumber;
        /// <summary>
        /// The amount been payed.
        /// </summary>
        public double? Payment => transaction.Payment;
        /// <summary>
        /// Indicates whether the client asked to deny the transaction.
        /// </summary>
        public bool IsDenied
        {
            get {
                if (transaction.IsDenied is null)
                    return false;
                return transaction.IsDenied.Value;
            }
        }
        /// <summary>
        /// The client that recived the payment.
        /// </summary>
        public ClientDataProxy RecieverClient => ClientDataProxy.GetProxy(transaction.ReciverClient);

        private TransactionClientProxy(Transaction transaction)
        {
            this.transaction = transaction;
            AddToTracking(this);
        }
        ~TransactionClientProxy() => Dispose();
        public void Dispose()
        {
            proxies.Remove(this);
        }
        private void AddToTracking(TransactionClientProxy proxy)
        {
            if (proxies.Find(proxy) is null)
                proxies.Add(proxy);
        }
        /// <summary>
        /// Marks the <see cref="transaction"/> as denied by the client and attach
        /// <paramref name="request"/> as the deny request.
        /// </summary>
        /// <param name="request">The request of the denia - must be on the db.</param>
        internal void Deny(RequestsFromClient request)
        {
            transaction.IsDenied = true;
            transaction.DenyRequest = request;
        }
        /// <summary>
        /// Retrieves the base <see cref="transaction"/>
        /// </summary>
        /// <returns></returns>
        internal Transaction GetTransaction()
        {
            return transaction;
        }
        #endregion
        #region StaticMembers
        private static List<TransactionClientProxy> proxies = new List<TransactionClientProxy>();

        /// <summary>
        /// Returns the proxy of <paramref name="transaction"/>.
        /// </summary>
        /// <param name="transaction">The transaction to proxify.</param>
        /// <returns></returns>
        public static TransactionClientProxy GetProxy(Transaction transaction)
        {
            if (transaction is null)
                return null;
            var proxy = proxies.Find((p) => { return p.TransactionId == transaction.TransactionId; });
            if (proxy is null)
                return new TransactionClientProxy(transaction);
            return proxy;
        }
        public static explicit operator TransactionClientProxy(Transaction t)
        {
            return GetProxy(t);
        }
        #endregion
    }
}