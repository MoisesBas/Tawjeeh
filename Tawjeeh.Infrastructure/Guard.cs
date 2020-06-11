using System;
using System.Collections.Generic;
using System.Linq;

namespace Tawjeeh.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void NotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void NotNull<T>(T value, string name) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public static void AreEqual<T>(T firstValue, T secondValue, string firstName, string lastName)
        {
            if (!EqualityComparer<T>.Default.Equals(firstValue, secondValue))
            {
                throw new ArgumentException(string.Format("{0} and {1} are not equal", firstName, secondValue));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void NotDefault<T>(T value, string name)
        {
            if (object.Equals(default(T), value))
            {
                throw new ArgumentException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void True(bool value, string name)
        {
            if (!value)
            {
                throw new ArgumentException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void False(bool value, string name)
        {
            if (value)
            {
                throw new ArgumentException(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="name"></param>
        public static void NotNullOrEmpty<T>(IEnumerable<T> list, string name)
        {
            if (list == null || !list.Any())
            {
                throw new ArgumentException(name);
            }
        }
    }
}
