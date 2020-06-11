using Microsoft.Practices.Unity;
using System.Web;

namespace Tawjeeh.Api.Plugins
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.Practices.Unity.LifetimeManager" />
    public class PerRequestLifetimeManager : LifetimeManager
    {
        /// <summary>
        /// The key
        /// </summary>
        private readonly object key = new object();

        /// <summary>
        /// Retrieve a value from the backing store associated with this Lifetime policy.
        /// </summary>
        /// <returns>
        /// the object desired, or null if no such object is currently stored.
        /// </returns>
        public override object GetValue()
        {
            if (HttpContext.Current != null && HttpContext.Current.Items.Contains(key))
                return HttpContext.Current.Items[key];
            else
                return null;
        }

        /// <summary>
        /// Remove the given object from backing store.
        /// </summary>
        public override void RemoveValue()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(key);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public override void SetValue(object newValue)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items[key] = newValue;
        }
    }
}