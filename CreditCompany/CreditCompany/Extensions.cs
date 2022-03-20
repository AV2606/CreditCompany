using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CreditCompanyEF.Models;
using CreditCompanyEF.Proxies;
using CreditCompanyEF;
//using CreditCompanyEF;

namespace CreditCompany.UserControls.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Makes sure the control is centerize in the x axis.
        /// </summary>
        /// <param name="c">The control to centerize.</param>
        public static void CenterHorizontal(this Control c)
        {
            var p = c.Parent;
            c.Location = new Point((p.Width - c.Width) / 2,c.Location.Y);
        }
        public static List<CardDisplay> ToCardDisplay(this IEnumerable<CreditCardClientProxy> me)
        {
            List<CardDisplay> r = new List<CardDisplay>();
            foreach (var item in me)
            {
                r.Add((CardDisplay)item);
            }
            return r;
        }
        /// <summary>
        /// Makes <typeparamref name="T"/> as <see cref="Displayer"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="displayLogic">The logic of displaying the data.</param>
        /// <returns></returns>
        public static Displayer<T> ToDisplayer<T>(this T me,ToString<T> displayLogic)
        {
            return new Displayer<T>(me, displayLogic);
        }
        /// <summary>
        /// Makes <see cref="IEnumerable{T}"/> as <see cref="List{Displayer}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <param name="displayLogic">The logic of displaying the data.</param>
        /// <returns></returns>
        public static List<Displayer<T>> ToDisplayerList<T>(this IEnumerable<T> me, ToString<T> displayLogic)
        {
            List<Displayer<T>> r = new List<Displayer<T>>();
            foreach (var item in me)
            {
                r.Add(new Displayer<T>(item, displayLogic));
            }
            return r;
        }
        public static IEnumerable<Banks> BanksEnumerable(this Banks me)
        {
            var arr=Enum.GetValues(typeof(Banks));
            foreach (var item in arr)
            {
                yield return (Banks)item;
            }
        }
    }
}
