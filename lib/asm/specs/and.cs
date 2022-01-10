//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using Operands;

    using static Root;
    using static Hex8Seq;

    partial class AsmSpecs
    {
        /// <summary>
        /// (AND AL, imm8)[24 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public static AsmHexCode and(al r, imm8 imm8, ref byte hex)
            => AsmHexCodes.define(x24, imm8);

        /// <summary>
        /// (AND r/m8, imm8)[80 /4 ib]
        /// </summary>
        /// <param name="r"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public static AsmHexCode and(r8b r, imm8 imm8, ref byte hex)
            => AsmHexCodes.define(x24, imm8);
    }
}