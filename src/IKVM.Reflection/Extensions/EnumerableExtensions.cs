using System.Collections.Generic;

namespace IKVM.Reflection.Extensions
{

    public static class EnumerableExtensions
    {

        /// <summary>
        /// Searches an enumeration for a value that matches the specified value and returns it's index, or -1 if the value is not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int IndexOf<T>(this IEnumerable<T> self, T value, IEqualityComparer<T> comparer = null)
        {
            comparer ??= EqualityComparer<T>.Default;

            var i = 0;
            foreach (var e in self)
            {
                if (comparer.Equals(e, value))
                    return i;

                i++;
            }

            return -1;
        }

    }

}
