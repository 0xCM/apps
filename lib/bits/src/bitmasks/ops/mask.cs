//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMasks
    {
        [MethodImpl(Inline),Op, Closures(Closure)]
        public static BitMask<T> mask<T>(T invariant)
            where T : unmanaged, IDataCell
                => new BitMask<T>(invariant);
    }
}