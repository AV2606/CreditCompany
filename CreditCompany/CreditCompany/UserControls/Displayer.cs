using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCompany.UserControls
{
    /// <summary>
    /// Used to make the <see cref="Displayer"/> know what to show as a display.
    /// </summary>
    /// <param name="item">The item that holds the data to display.</param>
    /// <returns></returns>
    public delegate string ToString<T>(T item);
    public class Displayer
    {
        protected object item;
        public object Item => item;

        public Displayer()
        {

        }
    }
    public class Displayer<T> : Displayer
    {
        protected ToString<T> display;
        public new T Item => (T)item;

        public Displayer(T item, ToString<T> display) : base()
        {
            this.item = item;
            this.display = display;
        }

        public override string ToString()
        {
            return display(Item);
        }
    }
}
