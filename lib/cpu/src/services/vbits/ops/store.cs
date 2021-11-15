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

    partial struct vbits
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(T src, byte index, ref Bitfield256<T> dst)
            where T : unmanaged
                => dst.State = cpu.vcell(dst.State, index, gmath.and(src, dst.Mask(index)));

        [MethodImpl(Inline)]
        public static void store<E,T>(T src, E index, ref Bitfield256<E,T> dst)
            where E : unmanaged
            where T : unmanaged
                => dst.State = cpu.vcell(dst.State, bw8(index), gmath.and(src, dst.Mask(index)));
    }
}
