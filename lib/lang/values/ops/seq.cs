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

    using Types;

    partial struct TV
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypedSeq<T> gseq<T>(T[] src)
            where T : IEquatable<T>
                => new TypedSeq<T>(src);

        public static TypedSeq<N,T> nseq<N,T>()
            where N : unmanaged, ITypeNat
            where T : IEquatable<T>
                => new TypedSeq<N,T>(alloc<T>(nat32u<N>()));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypedSeq<u8<T>> seq<T>(u8<T>[] src)
            where T : unmanaged, IEquatable<T>
                => gseq(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypedSeq<u16<T>> seq<T>(u16<T>[] src)
            where T : unmanaged, IEquatable<T>
                => gseq(src);
    }
}