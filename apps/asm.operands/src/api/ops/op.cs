//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using Operands;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmOperand op(RegOp src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(RegKind kind)
            => op(AsmRegs.reg(kind));

        [MethodImpl(Inline), Op]
        public static AsmOperand op(RegMask src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(RegOp target, RegIndex mask, RegMaskKind kind)
            => op(regmask(target,mask,kind));

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(xmm src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(ymm src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(zmm src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(rK src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(rSeg src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m128 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m256 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m512 src)
            => new AsmOperand(src);
    }
}