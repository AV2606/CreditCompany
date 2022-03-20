using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCompany
{
    public class EventedObject<T>
    {
        T value=default;
        /// <summary>
        /// The object.
        /// </summary>
        public T Value => value;

        /// <summary>
        /// Occurs after the value of the object has changed.
        /// </summary>
        public event EventHandler<(T previousValue, T newValue)> ValueChanged;
        /// <summary>
        /// Occurs before the value of the object has changed.
        /// </summary>
        public event EventHandler<(T currentValue, T newValue)> ValueChanging;


        public void Set(T newValue)
        {
            OnValueChanging(this.value, newValue);
            var v0 = this.value;
            this.value = newValue;
            OnValueChanged(v0, value);
        }

        protected void OnValueChanging(T value, T newValue)
        {
            ValueChanging?.Invoke(this, (value, newValue));
        }

        protected void OnValueChanged(T v0, T value)
        {
            ValueChanged?.Invoke(this, (v0, value));
        }

        public static implicit operator EventedObject<T>(T baseValue)=>new EventedObject<T>() { value=baseValue};
    }
}
