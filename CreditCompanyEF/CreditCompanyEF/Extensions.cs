using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCompanyEF
{
    /// <summary>
    /// All possible results from <see cref="Extensions.AddDistinct"/>
    /// </summary>
    public enum AddResult
    {
        /// <summary>
        /// Indicates that the entity is not a valid entity in the context.
        /// </summary>
        EntityDoesntExists = -1,
        /// <summary>
        /// Indicates that the entry already exists in the context (by reference).
        /// </summary>
        EntryAlreadyExistsInTheContext = -3,
        /// <summary>
        /// Indicates that the object that has been given is null.
        /// </summary>
        EntityIsNull = -4,
        /// <summary>
        /// Indicates that the entity has been added suceffuly.
        /// </summary>
        AddedSuccefully = 1,
    }
    public static class Extensions
    {
        /// <summary>
        /// Adds <paramref name="entity"/> to the context only if its not been tracked there already.
        /// </summary>
        /// <param name="me">The context to add <paramref name="entity"/> to.</param>
        /// <param name="entity">the entity to add.</param>
        /// <returns>The result of the operation</returns>
        public static AddResult AddDistinct(this DbContext me, object entity)
        {
            //var e=me.Entry(entity);
            //bool context = e.Context is null;
            //var track = e.State;
            try
            {
                if (me.Entry(entity).State == EntityState.Detached)
                {
                    me.Add(entity);
                    return AddResult.AddedSuccefully;
                }
                else
                {
                    return AddResult.EntryAlreadyExistsInTheContext;
                }
            }
            catch (ArgumentNullException e)
            {
                return AddResult.EntityIsNull;
            }
            catch (InvalidOperationException e)
            {
                return AddResult.EntityDoesntExists;
            }
            catch (Exception e)
            {
                //var type = e.GetType();
                throw;
            }
        }
        /// <summary>
        /// Makes the model collection as a proxy collection
        /// </summary>
        /// <typeparam name="TProxy"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="me"></param>
        /// <returns></returns>
        public static List<RequestFromClientProxy> ToProxies(this IEnumerable<RequestsFromClient> me)
        {
            var r = new List<RequestFromClientProxy>();
            foreach (var item in me)
            {
                r.Append(RequestFromClientProxy.GetProxy(item));
            }
            return r;
        }
    }
}
