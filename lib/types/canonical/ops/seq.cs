//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;


    using static Root;
    using static core;

    using ScalarTypes;

    partial struct TS
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> seq<T>(T[] src)
            => new Seq<T>(src);

        [Op, Closures(Closure)]
        public static Seq<N,T> seq<N,T>()
            where N : unmanaged, ITypeNat
                => new Seq<N,T>(alloc<T>(nat32u<N>()));

        [MethodImpl(Inline)]
        public static Outcome<uint> apply<S,T>(SeqProjector<S,T> p, ReadOnlySpan<S> src, Span<T> dst)
        {
            var count = (uint)min(src.Length,dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = p.F(skip(src,i));
            return count;
        }
    }
}