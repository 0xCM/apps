//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    partial struct AsmX
    {
        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndexCode r)
            => AsmRegs.reg(width, @class,r);

        [MethodImpl(Inline), Op]
        public static RegOp reg(RegKind kind)
            => AsmRegs.reg(kind);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => AsmRegs.reg(src);

        [MethodImpl(Inline), Op]
        public static RegMask regmask(RegOp target, RegIndex mask, RegMaskKind kind)
            => new RegMask(target,mask,kind);

        [MethodImpl(Inline), Op]
        public static r8 r8(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static r16 r16(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static r32 r32(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static r64 r64(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static xmm r128(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static ymm r256(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static zmm r512(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rK rK(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rCr rCr(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static rDb rDb(RegIndexCode r)
            => r;

        [MethodImpl(Inline), Op]
        public static xCr xCr(RegIndexCode r)
            => r;
    }
}