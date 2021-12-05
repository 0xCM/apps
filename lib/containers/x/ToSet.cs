//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    partial class XTend
    {
        /// <summary>
        /// Constructs a hash set from span content
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(Closure)]
        public static HashSet<T> ToSet<T>(this Span<T> src)
            where T : unmanaged
                => seq.set(src.ReadOnly());

        /// <summary>
        /// Constructs a hash set from span content
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(Closure)]
        public static HashSet<T> ToSet<T>(this ReadOnlySpan<T> src)
            where T : unmanaged
                => seq.set(src);

        /// <summary>
        /// Constructs a hash set from span content
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(Closure)]
        public static HashSet<T> ToSet<T>(this ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : unmanaged
                => seq.set(a,b);

        /// <summary>
        /// Constructs a hash set from span content
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The item type</typeparam>
        [Op, Closures(Closure)]
        public static HashSet<T> ToSet<T>(this Span<T> src, ReadOnlySpan<T> b)
            where T : unmanaged
                => src.ReadOnly().ToSet(b);
    }
}