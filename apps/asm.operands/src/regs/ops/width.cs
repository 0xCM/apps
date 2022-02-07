//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
     using System;
     using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmRegs
    {
        /// <summary>
        /// Determines the width of the register represented by a specified kind
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static NativeSizeCode width(RegKind src)
            => (NativeSizeCode)bits.slice((uint)src, (byte)RegFieldIndex.W, (byte)RegFieldWidth.RegWidth);

        /// <summary>
        /// Determines the width of a specified operand
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static NativeSizeCode width(RegOp src)
            => (NativeSizeCode)(src.Bitfield & 0b111);

        [MethodImpl(Inline), Op]
        public static ushort bitwidth(NativeSizeCode src)
            => src == NativeSizeCode.W80 ? (ushort)80 : (ushort)Pow2.pow((byte)(((byte)src) << 3));
    }
}