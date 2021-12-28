//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static uint endpos(uint offset, uint width)
            => ((offset + width) - 1);
    }
}