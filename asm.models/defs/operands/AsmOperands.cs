//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct AsmOperands
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
    }
}