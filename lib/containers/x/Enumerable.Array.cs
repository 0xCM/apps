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

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Creates a <typeparamref name='T'/> cell array from an enumerable <typeparamref name='T'/> cell sequence
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T[] Array<T>(this IEnumerable<T> src)
            => src == null ? System.Array.Empty<T>() : src.ToArray();

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Span<T> Span<T>(this IEnumerable<T> src)
            => src.ToArray();

        [MethodImpl(Inline)]
        public static T[] Array<T>(this T[] src)
            => src;
    }
}