using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            foreach (IEnumerable<T> streams in items)
            {
                foreach (T item in streams)
                    yield return item;
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (T item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }

            }
        }
        public static bool Even(int i)
        {
            return i % 2 == 0;
        }
    }
}
