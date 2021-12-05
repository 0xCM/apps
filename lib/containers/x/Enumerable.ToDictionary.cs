//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static Dictionary<K,V> ToDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            => new Dictionary<K,V>(src.Select(x => new KeyValuePair<K,V>(x.key, x.value)));

        public static Dictionary<string,V> ToDictionary<V>(this IEnumerable<NamedValue<V>> src)
            => src.Select(x => (x.Name, x.Value)).ToDictionary();

        /// <summary>
        /// Creates a read-only dictionary from an existing mutable dictionary
        /// </summary>
        /// <typeparam name="K">The dictionary key type</typeparam>
        /// <typeparam name="V">The dictionary value type</typeparam>
        /// <param name="src">The extended type</param>
        public static IReadOnlyDictionary<K,V> ReadOnly<K,V>(this IDictionary<K,V> src)
            => new Dictionary<K,V>(src);

        public static Dictionary<K,V> ToDictionary<K,V>(this IEnumerable<KeyedValue<K,V>> src)
            => src.Select(x => (x.Key, x.Value)).ToDictionary();
    }
}