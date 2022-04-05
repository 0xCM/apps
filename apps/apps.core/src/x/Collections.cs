//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this ReadOnlySpan<T> src, Func<T, bool> f)
            => ArrayUtil.where(src, f);

        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this T[] src, Func<T, bool> f)
            => ArrayUtil.where(src, f);

        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this Span<T> src, Func<T, bool> f)
            => ArrayUtil.where(src, f);

       [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this T[] src)
            => src;

        [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this IEnumerable<T> src)
            => src.Array();

        public static Index<T> Append<T>(this Span<T> head, ReadOnlySpan<T> tail)
        {
            var count = head.Length + tail.Length;
            var dst = alloc<T>(count);
            var j=0;
            for(var i=0; i<head.Length; i++, j++)
                seek(dst,j) = skip(head,i);
            for(var i=0; i<tail.Length; i++, j++)
                seek(dst,j) = skip(tail,i);
            return dst;
        }

        public static Index<T> Append<T>(this Index<T> head, ReadOnlySpan<T> tail)
            => head.Edit.Append(tail);

        public static Index<T> Append<T>(this T[] head, ReadOnlySpan<T> tail)
            => @span(head).Append(tail);

        public static uint AddRange<T>(this HashSet<T> dst, ReadOnlySpan<T> src)
        {
            var counter = 0u;
            foreach(var item in src)
                if(dst.Add(item))
                    counter++;
            return counter;
        }

        public static uint AddRange<T>(this HashSet<T> dst, params T[] src)
            => dst.AddRange(@readonly(src));
    }
}