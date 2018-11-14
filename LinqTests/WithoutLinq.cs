using LinqTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSample.WithoutLinq
{
    internal static class WithoutLinq
    {
        public static IEnumerable<Product> Find(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.IsTopSaleProducts())
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<Product> Find(IEnumerable<Product> products, Predicate<Product> p)
        {
            foreach (var product in products)
            {
                if (p(product))
                {
                    yield return product;
                }
            }
        }

        internal static IEnumerable<T> Find<T>(this IEnumerable<T> employees, Func<T, int, bool> p)
        {
            var index = 0;
            foreach (var employee in employees)
            {
                if (p(employee, index))
                {
                    yield return employee;
                }
                index++;
            }
        }

        public static IEnumerable<T> YourWhere<T>(this IEnumerable<T> sources, Func<T, bool> p)
        {
            foreach (var source in sources)
            {
                if (p(source))
                {
                    yield return source;
                }
            }
        }

        public static IEnumerable<TResult> YourSelect<T, TResult>(this IEnumerable<T> sources, Func<T, TResult> selector)
        {
            foreach (var source in sources)
            {
                yield return selector(source);
            }
        }

        public static IEnumerable<T> Take<T>(IEnumerable<T> sources, int i)
        {
            var index = 0;
            foreach (var source in sources)
            {
                if (index < i)
                {
                    yield return source;
                }
                index++;
            }
        }

        public static IEnumerable<T> YourSkip<T>(IEnumerable<T> sources, int i)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index >= i)
                {
                    yield return enumerator.Current;
                }
                index++;
            }
        }

        public static IEnumerable<T> YourTakeWhile<T>(IEnumerable<T> employees, int i, Func<T, bool> func)
        {
            if (employees == null)
            {
                throw new ArgumentException();
            }
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index >= i)
                {
                    yield break;
                }
                var current = enumerator.Current;
                if (func(current))
                {
                    yield return current;
                    index++;
                }
            }
        }

        public static IEnumerable<T> YourSkipWhile<T>(IEnumerable<T> sources, int i, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                if (index < i && func(enumerator.Current))
                {
                    index++;
                }
                else
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static IEnumerable<int> YourGroup<TSource>(IEnumerable<TSource> sources, int numberOfGroup, Func<TSource, int> func)
        
        {
            var sumOfSalaryForEachGroup = 0;
            var index = 1;
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                sumOfSalaryForEachGroup += func(enumerator.Current);
                if (index++ % numberOfGroup == 0)
                {
                    yield return sumOfSalaryForEachGroup;
                    sumOfSalaryForEachGroup = 0;
                }

            }

            if (sumOfSalaryForEachGroup>0)
            {
                yield return sumOfSalaryForEachGroup;
            }

           
        }

        public static T YourFirst<T>(IEnumerable<T> sources, Func<T, bool> func)
        {
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                {
                    return enumerator.Current;
                }
            }
            throw new ArgumentNullException();
        }

        public static T YourLast<T>(IEnumerable<T> sources, Func<T, bool> func)
        {
            var reversedSource = sources.Reverse();
            var enumerator = reversedSource.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                {
                    return enumerator.Current;
                }
            }

            throw new ArgumentNullException();
        }
    }
}