//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte segwidth<T>(in Bitfield256<T> src, byte index)
            where T : unmanaged
                => cpu.vcell(src.Widths, index);

        [MethodImpl(Inline)]
        public static byte segwidth<E,T>(in Bitfield256<E,T> src, E index)
            where E : unmanaged
            where T : unmanaged
                => cpu.vcell(src.Widths, bw8(index));
    }
}