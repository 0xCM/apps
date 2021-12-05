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
    using static core;

    partial class XTend
    {
        /// <summary>
        /// Creates a dictionary from a span using the element indices as keys
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static IDictionary<K,V> ToDictionary<K,V>(this ReadOnlySpan<(K,V)> src)
        {
            var count = src.Length;
            var dst = dict<K,V>(count);
            for(var i = 0u; i<count; i++)
            {
                ref readonly var kv = ref skip(src,i);
                dst.TryAdd(kv.Item1, kv.Item2);
            }
            return dst;
        }

        /// <summary>
        /// Creates a dictionary from a span using the element indices as keys
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static IDictionary<K,V> ToDictionary<K,V>(this Span<(K,V)> src)
            => src.ReadOnly().ToDictionary();
    }
}