using System;
using System.Collections.Generic;
using System.Text;

namespace IKVM.Reflection.Extensions
{

    public static class StringBuilderExtensions
    {

        /// <summary>
        /// Appends a seperator joined list to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="items"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static StringBuilder AppendJoin<T>(this StringBuilder self, IReadOnlyList<T> items, string seperator, Action<StringBuilder, T> action)
        {
            for (int i = 0; i < items.Count; i++)
            {
                action(self, items[i]);
                if (i < items.Count - 1)
                    self.Append(seperator);
            }

            return self;
        }

        /// <summary>
        /// Appends a seperator joined list to the <see cref="StringBuilder"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static StringBuilder AppendJoin<T>(this StringBuilder self, IReadOnlyList<T> items, string seperator)
        {
            for (int i = 0; i < items.Count; i++)
            {
                self.Append(items[i]);
                if (i < items.Count - 1)
                    self.Append(seperator);
            }

            return self;
        }

    }

}
