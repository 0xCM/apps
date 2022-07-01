//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        public static Dictionary<K,V> ToDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            => new Dictionary<K,V>(src.Select(x => new KeyValuePair<K,V>(x.key, x.value)));

        public static Dictionary<uint,T> ToIndexDictionary<T>(this ReadOnlySpan<T> src)
            => core.mapi(src, (i,x) => ((uint)i,x)).ToDictionary();

        public static Dictionary<uint,T> ToIndexDictionary<T>(this Span<T> src)
            => core.@readonly(src).ToIndexDictionary();

        public static Dictionary<uint,T> ToIndexDictionary<T>(this Index<T> src)
            => core.@readonly(src.Storage).ToIndexDictionary();

        public static Dictionary<uint,T> ToIndexDictionary<T>(this T[] src)
            => core.@readonly(src).ToIndexDictionary();

        public static ConstLookup<K,V> ToConstLookup<K,V>(this IEnumerable<(K key, V value)> src)
            => src.ToDictionary();

        public static Dictionary<NameOld,V> ToDictionary<V>(this IEnumerable<NamedValue<V>> src)
            => src.Select(x => (x.Name, x.Value)).ToDictionary();

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            where K : IComparable<K>
                => new SortedDictionary<K,V>(src.ToDictionary());

        public static SortedLookup<K,V> ToSortedLookup<K,V>(this IEnumerable<(K key, V value)> src)
            where K : IComparable<K>
                => new SortedLookup<K,V>(src.ToDictionary());

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this IEnumerable<(K,V)> src, IComparer<K> comparer)
            => new SortedDictionary<K,V>(src.ToDictionary(), comparer);

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

        public static LookupProjector<K,V,T> ToLookupProjector<K,V,T>(this IEnumerable<(K key, V value)> src, IProjector<V,T> projector)
            => src.ToDictionary().ToLookupProjector(projector);

        public static LookupProjector<K,V,T> ToLookupProjector<K,V,T>(this ConcurrentDictionary<K,V> src, IProjector<V,T> projector)
            => new LookupProjector<K,V,T>(src,projector);

        public static LookupProjector<K,V,T> ToLookupProjector<K,V,T>(this IDictionary<K,V> src, IProjector<V,T> projector)
            => new LookupProjector<K,V,T>(src,projector);
    }
}