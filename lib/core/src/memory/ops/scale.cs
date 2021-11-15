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
        public static MemoryScale scale(byte factor)
            => new MemoryScale((ScaleFactor)factor);

        [MethodImpl(Inline), Op]
        public static MemoryScale scale(ScaleFactor factor)
            => new MemoryScale(factor);
    }
}