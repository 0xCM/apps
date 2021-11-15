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
    using static BitMaskLiterals;
    using static cpu;

    partial struct vbits
    {
        /// <summary>
        /// Distributes each source bit to to a specified bit of each byte in a 256-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vmap32x1(uint src, byte index, out Vector256<byte> dst)
        {
            var m = Lsb64x8x1 << index;
            var lo = v8u(vparts(BitMasks.maskpart(src, 0, m), BitMasks.maskpart(src, 8, m)));
            var hi = v8u(vparts(BitMasks.maskpart(src, 16, m), BitMasks.maskpart(src, 24, m)));
            dst = cpu.vconcat(lo,hi);
            return dst;
        }
    }
}