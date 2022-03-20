using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies.Extensions;
using System;
using System.Collections.Generic;

namespace CreditCompanyEF.Proxies
{
    public class CreditCardClientProxy:IProxy
    {
        #region InstanceMembers
        internal Models.CreditCard creditCard;

        public int? AccountId => creditCard.AccountId;
        public int? ClientId => creditCard.ClientId;
        public string Club => creditCard.Club;
        public double? Credit => creditCard.Credit;
        public double? UsedCredit => creditCard.UsedCredit;
        public string CreditCardNumber => creditCard.CreditCardNumber;
        public bool IsCanceled => creditCard.IsCanceled;
        public bool IsRecievingOnly => creditCard.IsRecievingOnly;
        public IReadOnlyList<TransactionClientProxy> Transactions => creditCard.Transactions.ToProxyList();


        private CreditCardClientProxy(Models.CreditCard card)
        {
            this.creditCard = card;
            AddToTracking(this);
        }
        ~CreditCardClientProxy()
        {
            Dispose();
        }
        private void AddToTracking(CreditCardClientProxy self)
        {
            if (proxies.Find(self) is null)
                proxies.Add(self);
        }
        public void Dispose()
        {
            proxies.Remove(this);
        }
        #endregion
        #region StaticMembers

        private static List<CreditCardClientProxy> proxies = new List<CreditCardClientProxy>();
        public static CreditCardClientProxy GetProxy(Models.CreditCard card)
        {
            var proxy = proxies.Find((p) => { return p.CreditCardNumber == card.CreditCardNumber; });
            if (proxy is null)
                return new CreditCardClientProxy(card);
            return proxy;
        }


        public static explicit operator CreditCardClientProxy(Models.CreditCard c)
        {
            return GetProxy(c);
        }
        #endregion
    }
}