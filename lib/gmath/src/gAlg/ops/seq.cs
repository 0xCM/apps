//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct gcalc
    {
        [Op, Closures(Closure)]
        public static Seq<T> seq<T>(params T[] src)
            => seq<T>(@readonly(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> seq<T>(params SeqTerm<T>[] src)
            => new Seq<T>(src);

        [Op, Closures(Closure)]
        public static Seq<T> seq<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            if(count != 0)
            {
                var terms = alloc<SeqTerm<T>>(count);
                var dst = span(terms);
                for(var i=0u; i<count; i++)
                    seek(dst,i) = new SeqTerm<T>(i, skip(src,i));
                return new Seq<T>(terms);
            }
            else
                return Seq<T>.Empty;
        }
    }
}