//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    using Operands;

    [ApiHost]
    public readonly struct AsmOperands
    {
        [Op]
        public static AsmOperand define(RegOp src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(imm8 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(imm16 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(imm32 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(imm64 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m8 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m16 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m32 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m64 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m128 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m256 src)
            => new AsmOperand(src);

        [Op]
        public static AsmOperand define(m512 src)
            => new AsmOperand(src);
    }
}