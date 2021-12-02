//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Operands;

    [ApiHost]
    public readonly struct AsmOps
    {
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

        [MethodImpl(Inline), Op]
        public static AsmOperand mem8(RegOp @base)
            => op(new m8(@base, RegOp.Invalid, 0, Disp.Zero));

        [MethodImpl(Inline), Op]
        public static AsmOperand mem16(RegOp @base)
            => op(new m16(@base, RegOp.Invalid, 0, Disp.Zero));

        [MethodImpl(Inline), Op]
        public static AsmOperand mem32(RegOp @base)
            => op(new m32(@base, RegOp.Invalid, 0, Disp.Zero));

        [MethodImpl(Inline), Op]
        public static AsmOperand mem64(RegOp @base)
            => op(new m64(@base, RegOp.Invalid, 0, Disp.Zero));

        [MethodImpl(Inline), Op]
        public static AsmOperand mem128(RegOp @base)
            => op(new m128(@base, RegOp.Invalid, 0, Disp.Zero));

        [MethodImpl(Inline), Op]
        public static AsmOperand mem256(RegOp @base)
            => op(new m256(@base, RegOp.Invalid, 0, Disp.Zero));

        [MethodImpl(Inline), Op]
        public static AsmOperand mem512(RegOp @base)
            => op(new m512(@base, RegOp.Invalid, 0, Disp.Zero));
    }
}