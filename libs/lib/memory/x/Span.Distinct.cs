//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        [Op, Closures(Closure)]
        public static Index<T> Distinct<T>(this ReadOnlySpan<T> src)
            where T : IEquatable<T>
        {
            var dst = hashset<T>();
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.Add(skip(src,i));
            return dst.Array();
        }

        [Op, Closures(Closure)]
        public static Index<T> Distinct<T>(this Span<T> src)
            where T : IEquatable<T>
                => @readonly(src).Distinct();
    }
}