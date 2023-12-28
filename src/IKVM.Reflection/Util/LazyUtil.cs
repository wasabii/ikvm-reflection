using System;
using System.Threading;

namespace IKVM.Reflection.Util
{

    public static class LazyUtil
    {

        /// <summary>
        /// Invokes the create function to obtain a new value only if the existing value is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static T Get<T>(ref T? self, Func<T> create)
            where T : class
        {
            if (self == null)
                Interlocked.CompareExchange(ref self, create(), null);

            return self;
        }

    }

}
