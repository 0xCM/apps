//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline)]
        static int width<E>(E field)
            where E : unmanaged
        {
            var w = core.@as<E,uint>(field) >> 16;
            return (int)w;
        }

        [MethodImpl(Inline)]
        public static DelimitedIndex<T> Delimit<T>(this T[] src, char delimiter = ListDelimiter, int pad = 0, Fence<char>? fence = null)
            => new DelimitedIndex<T>(src, delimiter, pad, fence);

        [MethodImpl(Inline)]
        public static DelimitedIndex<T> Delimit<T>(this IEnumerable<T> src, char delimiter = ListDelimiter, int pad = 0, Fence<char>? fence = null)
            => new DelimitedIndex<T>(src.Array(), delimiter, pad, fence);

        [MethodImpl(Inline)]
        public static DelimitedSpan<T> Delimit<T>(this ReadOnlySpan<T> src, char delimiter = ListDelimiter, int pad = 0, Fence<char>? fence = null)
            => Seq.delimit(delimiter, pad, src);

        [MethodImpl(Inline)]
        public static DelimitedSpan<T> Delimit<T>(this Span<T> src, char delimiter = ListDelimiter, int pad = 0, Fence<char>? fence = null)
            => Seq.delimit(delimiter, pad, src);

        [MethodImpl(Inline)]
        public static DelimitedIndex<T> Delimit<T>(this IIndex<T> src, char delimiter = ListDelimiter, int pad = 0, Fence<char>? fence = null)
            => new DelimitedIndex<T>(src.Storage, delimiter, pad, fence);
    }
}