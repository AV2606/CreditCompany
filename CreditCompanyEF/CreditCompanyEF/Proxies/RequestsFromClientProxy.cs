using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCompanyEF.Proxies
{
    public class RequestFromClientProxy : IProxy
    {
        #region InstanceMembers
        internal RequestsFromClient request;
        /// <summary>
        /// The id of the request.
        /// </summary>
        protected int Id => request.RequestId;
        /// <summary>
        /// Indicates whether the request has been viewed or not.
        /// </summary>
        public bool? IsViewed => request.HasBeenViewd;
        /// <summary>
        /// The title of the request.
        /// </summary>
        public string Title => request.Title;
        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Content => request.Content;
        /// <summary>
        /// Retrives the id of the client sent this request.
        /// </summary>
        public int? ClientId => request.ClientId;



        private RequestFromClientProxy(RequestsFromClient request)
        {
            this.request = request;
            AddToTracking(this);
        }
        ~RequestFromClientProxy() => Dispose();

        public void Dispose()
        {
            proxies.Remove(this);
        }
        private void AddToTracking(RequestFromClientProxy self)
        {
            if (proxies.Find(self) is null)
                proxies.Add(self);
        }
        #endregion
        #region StaticMembers

        private static List<RequestFromClientProxy> proxies = new List<RequestFromClientProxy>();
        /// <summary>
        /// Returns the proxy of <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request to proxify.</param>
        /// <returns></returns>
        public static RequestFromClientProxy GetProxy(RequestsFromClient request)
        {
            var proxy = proxies.Find((p) => { return request.RequestId == p.Id; });
            if (proxy is null)
                return new RequestFromClientProxy(request);
            return proxy;
        }


        public static explicit operator RequestFromClientProxy(RequestsFromClient request)
        {
            return GetProxy(request);
        }
        #endregion
    }
}
