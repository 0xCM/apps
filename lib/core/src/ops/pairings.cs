//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        [MethodImpl(Inline)]
        public static Pairings<A,B> pairings<A,B>(Paired<A,B>[] src)
            => src;
    }
}