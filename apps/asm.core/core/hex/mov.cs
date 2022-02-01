//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static AsmPrefixCodes;

    partial class AsmHexSpecs
    {
        // REX.W + B8+ rd io | MOV r64, imm64           | OI    | Valid       | N.E.            | Move imm64 to r64.                                             |
        [MethodImpl(Inline), Op]
        public static byte mov(r64 r, imm64 imm, ref byte dst)
            => AsmHexCodes.encode(RexW, (Hex8)(0xb8 + (byte)r.Index), imm, ref dst);
    }
}