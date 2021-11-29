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
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static Arrow<Node<T>> connect<T>(in Node<T> src, in Node<T> dst)
        //     where T : unmanaged
        //         => new Arrow<Node<T>>(src, dst);
        // [MethodImpl(Inline)]
        // public static Arrow<V> connect<V,T>(in Node<V,T> src, in Node<V,T> dst)
        //     where V : unmanaged
        //     where T : unmanaged
        //         => new Arrow<V>(src.Index, dst.Index);
    }
}