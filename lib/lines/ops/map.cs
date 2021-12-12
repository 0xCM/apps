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

    partial struct Lines
    {
        [MethodImpl(Inline)]
        public static LineMap<T> map<T>(LineInterval<T>[] src)
            => src;
    }
}