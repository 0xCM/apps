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


    using Canonical;


    partial struct TS
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> gseq<T>(T[] src)
            where T : IType
                => new Seq<T>(src);

        public static Seq<N,T> nseq<N,T>()
            where N : unmanaged, ITypeNat
            where T : IType
                => new Seq<N,T>(alloc<T>(nat32u<N>()));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<u8<T>> seq<T>(u8<T>[] src)
            where T : unmanaged
                => gseq(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<u16<T>> seq<T>(u16<T>[] src)
            where T : unmanaged
                => gseq(src);

    }
}