//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Initializes an empty dictionary
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>()
            => new Dictionary<K,V>();

        /// <summary>
        /// Initializes an empty dictionary with a specified capacity
        /// </summary>
        /// <param name="capacity">The initial capacity</param>
        /// <param name="kRep">A key representative used only for type inference</param>
        /// <param name="vRep">A value representative used only for type inference</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>(Count capacity)
            => new((int)capacity);

        /// <summary>
        /// Creates a dictionary, excluding any duplicates, and invokes a caller-supplied action for each encountered duplicate
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>(Action<KeyedValue<K,V>> duplicate, params (K key,V value)[] kvp)
        {
            var src = span(kvp);
            var count = src.Length;
            var dst = dict<K,V>(count);

            for(var i=0u; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                if(!dst.TryAdd(entry.key, entry.value))
                    duplicate(entry);
            }
            return dst;
        }

        [MethodImpl(Inline)]
        static void ThrowDuplicated<K,V>(KeyedValue<K,V> kvp)
            => sys.@throw(new Exception($"The key {kvp.Key} for {kvp.Value} is not unique"));

        /// <summary>
        /// Creates a dictionary, throwing an exception if a duplicate key is encountered
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The vale type</typeparam>
        [MethodImpl(Inline)]
        public static Dictionary<K,V> dict<K,V>(params (K key,V value)[] kvp)
            => dict(ThrowDuplicated, kvp);
    }
}