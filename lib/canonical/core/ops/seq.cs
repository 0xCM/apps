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
        public static Seq<T> seq<T>(T[] src)
            where T : IType
            => new Seq<T>(src);

        [Op, Closures(Closure)]
        public static Seq<N,T> seq<N,T>()
            where N : unmanaged, ITypeNat
            where T : IType
                => new Seq<N,T>(alloc<T>(nat32u<N>()));


    }
}