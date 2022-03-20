using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies.Extensions;
using System;
using System.Collections.Generic;

namespace CreditCompanyEF.Proxies
{

    /// <summary>
    /// A proxy that handles the <see cref="Message"/> for the client.
    /// </summary>
    public class MessageClientProxy:IProxy
    {
        #region InstanceMembers
        private Message message;
        /// <summary>
        /// The id of the message.
        /// </summary>
        protected int Id => message.MessageId;
        /// <summary>
        /// Indicates whether the message has been viewed or not.
        /// </summary>
        public bool? IsViewed => message.IsViewed;
        /// <summary>
        /// The title of the message.
        /// </summary>
        public string Title => message.MessageTitle;
        /// <summary>
        /// The content of the message.
        /// </summary>
        public string Content => message.MessageContent;


        private MessageClientProxy(Message message)
        {
            this.message = message;
            AddToTracking(this);
        }
        ~MessageClientProxy() => Dispose();

        public void Dispose()
        {
            proxies.Remove(this);
        }
        /// <summary>
        /// Marks the message as read.
        /// </summary>
        /// <param name="client"></param>
        internal void MarkAsRead(Client client)
        {
            if (this.message.ClientReciever == client)
            {
                this.message.IsViewed = true;
                using(var context=new CreditCompanyContext())
                {
                    var entry=context.Entry(this.message);
                    if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    {
                        entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;  
                    }
                    //else
                        entry.Context.SaveChanges();
                }
            }
        }
        private void AddToTracking(MessageClientProxy self)
        {
                if (proxies.Find(self) is null)
                    proxies.Add(self);
        }
        #endregion
        #region StaticMembers

        private static List<MessageClientProxy> proxies = new List<MessageClientProxy>();
        /// <summary>
        /// Returns the proxy of <paramref name="msg"/>.
        /// </summary>
        /// <param name="msg">The message to proxify.</param>
        /// <returns></returns>
        public static MessageClientProxy GetProxy(Message msg)
        {
            var proxy = proxies.Find((p) => { return msg.MessageId == p.Id; });
            if (proxy is null)
                return new MessageClientProxy(msg);
            return proxy;
        }


        public static explicit operator MessageClientProxy(Message msg)
        {
            return GetProxy(msg);
        }
        #endregion
    }
}