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

    partial struct vpack
    {
        /// <summary>
        /// Distributes each source bit to an index-identified bit of each byte in a 128-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The bit position index, an integer in the range [0,7]</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vunpack1x16(ushort src, byte index)
        {
            var m = Lsb64x8x1 << index;
            return v8u(vparts(BitMasks.maskpart(src,0, m), BitMasks.maskpart(src,8, m)));
        }
    }
}