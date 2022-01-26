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
    using static AsmPrefixCodes;

    partial class AsmHexSpecs
    {
        // REX.W + B8+ rd io | MOV r64, imm64           | OI    | Valid       | N.E.            | Move imm64 to r64.                                             |
        [MethodImpl(Inline), Op]
        public static AsmHexCode mov(r64 r64, imm64 imm64)
            => AsmHexCodes.define(RexW, (Hex8)(0xb8 + (byte)r64.Index), imm64);
    }
}