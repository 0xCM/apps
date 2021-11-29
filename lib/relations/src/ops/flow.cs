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
        // public static DataFlow<S,T> flow<S,T>(in S src, in T dst)
        //     => new DataFlow<S,T>(src,dst);
    }
}