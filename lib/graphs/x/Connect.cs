//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        // [MethodImpl(Inline)]
        // public static Arrow<V> Connect<V,T>(this Node<V,T> src, Node<V,T> dst)
        //     where V : unmanaged
        //     where T : unmanaged
        //         => flows.connect(src,dst);
        // [MethodImpl(Inline)]
        // public static Arrow<Node<V>> Connect<V>(this Node<V> src, Node<V> dst)
        //     where V : unmanaged
        //         => flows.connect(src,dst);
    }
}