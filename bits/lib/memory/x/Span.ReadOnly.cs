//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Presents a mutable span as a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> ReadOnly<T>(this Span<T> src)
            => src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Invert<T>(this Span<T> src)
        {
            src.Reverse();
            return src;
        }
    }
}