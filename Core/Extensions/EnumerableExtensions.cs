using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public static class EnumerableExtensions
    {

        public static IEnumerable<TSource> DistinctBy<TSource, TSelection>(this IEnumerable<TSource> source, Func<TSource, TSelection> selector)
        {
            return source.Distinct(new SelectorEqualityComparer<TSource, TSelection>(selector));
        }

        private class SelectorEqualityComparer<TSource, TSelection> : IEqualityComparer<TSource>
        {
            public Func<TSource, TSelection> _selector;

            public SelectorEqualityComparer(Func<TSource, TSelection> selector)
            {
                _selector = selector;
            }

            public bool Equals(TSource x, TSource y)
            {
                return Object.Equals(_selector(x), _selector(y));
            }

            public int GetHashCode(TSource obj)
            {
                return _selector(obj).GetHashCode();
            }
        }
    }
}
