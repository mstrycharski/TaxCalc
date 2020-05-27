using System;
using System.Collections.Generic;

namespace TaxCalc.Extensions
{
    internal static class EnumerableExtensions
    {
        public static bool HasDuplicate<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var checkBuffer = new HashSet<T>();
            foreach (var t in source)
            {
                if (checkBuffer.Add(t))
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
