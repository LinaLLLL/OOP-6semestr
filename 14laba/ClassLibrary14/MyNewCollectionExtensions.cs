using ClassLibrary13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary14
{
    public delegate bool Condition<in T>(T item); // для выборки
    public delegate TResult Aggregator<T, TResult>(TResult acc , T item); // для агрегирования
    public delegate TKey KeySelector<T, TKey>(T obj); // для сортировки и группировки
    public static class MyNewCollectionExtensions
    {
        //выборка по условию
        public static IEnumerable<T> WhereCustom<T>(this MyNewCollection<T> collection, Condition<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        // агрегирование
        public static TResult AggregateCustom<T, TResult>(this MyNewCollection<T> collection, TResult seed, Aggregator<T, TResult> aggregator)
        {
            TResult result = seed;
            foreach (var item in collection)
            {
                result = aggregator(result, item);
            }
            return result;
        }

        //сортировка
        public static IEnumerable<T> OrderByCustom<T,Tkey>(this MyNewCollection<T> collection, KeySelector<T,Tkey> keySelector, bool descending = false)
        {
            if(descending)
                return collection.OrderByDescending(item => keySelector(item));
            else
                return collection.OrderBy(item => keySelector(item));
        }

        //группировка
        public static IEnumerable<IGrouping<TKey, T>> GroupByCustom<T, TKey>(this MyNewCollection<T> collection,KeySelector<T, TKey> keySelector)
        {
            return collection.GroupBy(new Func<T, TKey>(keySelector));
        }
    }
}
