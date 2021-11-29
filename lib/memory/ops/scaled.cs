//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op]
        public static ScaledIndex scaled(ushort cell, sbyte dx, uint i)
            => new ScaledIndex(cell, dx, i);
    }
}