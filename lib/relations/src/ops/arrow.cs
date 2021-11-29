//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct relations
    {
        // [MethodImpl(Inline)]
        // public static Arrow<S,T> arrow<S,T>(S src, T dst)
        //     => new Arrow<S,T>(src, dst);

        // [MethodImpl(Inline)]
        // public static Arrow<K,V> arrow<K,V>(in Facet<K,V> src)
        //     => arrow(src.Key,src.Value);

        // [MethodImpl(Inline)]
        // public static Arrow<S,T,K> arrow<S,T,K>(S src, T dst, K kind)
        //     where K : unmanaged
        //         => new Arrow<S,T,K>(src, dst, kind);
    }
}