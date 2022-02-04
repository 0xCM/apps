//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
     using System;
     using System.Runtime.CompilerServices;

    using static Root;
    using static math;
    using static core;

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode size, RegClassCode @class, RegIndexCode index)
            => new RegOp(or((byte)size, sll((ushort)@class, 5), sll((ushort)index, 10)));

        [MethodImpl(Inline), Op]
        public static RegOp gp8(RegIndexCode r)
            => reg(NativeSizeCode.W8, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp gp16(RegIndexCode r)
            => reg(NativeSizeCode.W16, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp gp32(RegIndexCode r)
            => reg(NativeSizeCode.W32, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp gp64(RegIndexCode r)
            => reg(NativeSizeCode.W64, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp mask(RegIndexCode r)
            => reg(NativeSizeCode.W64, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp v128(RegIndexCode r)
            => reg(NativeSizeCode.W128, RegClassCode.XMM, r);

        [MethodImpl(Inline), Op]
        public static RegOp v256(RegIndexCode r)
            => reg(NativeSizeCode.W128, RegClassCode.YMM, r);

        [MethodImpl(Inline), Op]
        public static RegOp v512(RegIndexCode r)
            => reg(NativeSizeCode.W128, RegClassCode.ZMM, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK(RegIndexCode r)
            => reg(NativeSizeCode.W64, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK8(RegIndexCode r)
            => reg(NativeSizeCode.W8, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK16(RegIndexCode r)
            => reg(NativeSizeCode.W16, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK32(RegIndexCode r)
            => reg(NativeSizeCode.W32, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK64(RegIndexCode r)
            => reg(NativeSizeCode.W64, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp reg(RegKind kind)
            => new RegOp((ushort)kind);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => new RegOp(first(span16u(src.Data)));

        [MethodImpl(Inline), Op]
        public static RegOp sptr(RegIndexCode r)
            => reg(NativeSizeCode.W16, RegClassCode.SPTR, r);

        [MethodImpl(Inline), Op]
        public static RegOp seg(RegIndexCode r)
            => reg(NativeSizeCode.W16, RegClassCode.SEG, r);
    }
}