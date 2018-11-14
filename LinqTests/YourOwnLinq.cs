using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSample.YourOwnLinq
{
    internal static class YourOwnLinq
    {
        public static IEnumerable<int> YourGroup<TSource>(IEnumerable<TSource> sources, int numberOfGroup, Func<TSource, int> func)
        {
            for (int i = 0; i < sources.Count(); i+=numberOfGroup)
            {
                yield return sources.Skip(i).Take(numberOfGroup).Sum(func);
            }

        }
 
    }
}