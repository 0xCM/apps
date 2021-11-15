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
        /// Partitions a 32-bit source value into 32 8-bit pieces each with an effective width of 1
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vunpack1x32(uint src)
        {
            var a = vbroadcast(w256, src);
            var b = vbroadcast(w256, Msb32x8x7);
            return v8u(vand(a,b));
        }
    }
}