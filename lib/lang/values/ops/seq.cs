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

    using Expr;

    partial struct TV
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> gseq<T>(T[] src)
            where T : IEquatable<T>
                => new Seq<T>(src);

        public static NamedSeq<N,T> nseq<N,T>(Name name)
            where N : unmanaged, ITypeNat
            where T : IEquatable<T>
                => new NamedSeq<N,T>(name, alloc<T>(nat32u<N>()));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<u8<T>> seq<T>(u8<T>[] src)
            where T : unmanaged, IEquatable<T>
                => gseq(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<u16<T>> seq<T>(u16<T>[] src)
            where T : unmanaged, IEquatable<T>
                => gseq(src);
    }
}