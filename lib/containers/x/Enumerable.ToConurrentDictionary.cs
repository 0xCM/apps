//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Creates a concurrent dictionary from an ordinary dictionary
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="d">The source dictionary</param>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this IDictionary<K,V> d)
            => new ConcurrentDictionary<K,V>(d);

        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            => new ConcurrentDictionary<K, V>(src.Select(x => new KeyValuePair<K,V>(x.key, x.value)));

        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this ReadOnlySpan<(K key, V value)> src)
            => new ConcurrentDictionary<K, V>(core.map(src,x => new KeyValuePair<K,V>(x.key, x.value)));

        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this Span<(K key, V value)> src)
            => new ConcurrentDictionary<K, V>(core.map(src,x => new KeyValuePair<K,V>(x.key, x.value)));

        /// <summary>
        /// Creates a concurrent dictionary from the input sequence
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="values">The input sequence</param>
        /// <param name="keySelector"></param>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this IEnumerable<V> values, Func<V, K> keySelector)
            => new ConcurrentDictionary<K,V>(
                from value in values select new KeyValuePair<K,V>(keySelector(value), value));

        /// <summary>
        /// Creates a concurrent dictionary from the input sequence
        /// </summary>
        /// <typeparam name="S">The input sequence type</typeparam>
        /// <typeparam name="K">The dictionary key type</typeparam>
        /// <typeparam name="V">The type of the indexed valuie</typeparam>
        /// <param name="sources">The input sequence</param>
        /// <param name="keySelector">Function that selects the key</param>
        /// <param name="valueSelector">Function that selects the value</param>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<S,K,V>(this IEnumerable<S> sources, Func<S,K> keySelector, Func<S,V> valueSelector)
            => new ConcurrentDictionary<K,V>(from item in sources select new KeyValuePair<K,V>(keySelector(item), valueSelector(item)));
    }
}