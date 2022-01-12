//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Seq
    {
        [MethodImpl(Inline), Op]
        public static SizedLocation location(ushort seq, ushort size, uint offset)
            => new SizedLocation(seq, size, offset);
    }
}