//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static AsmPrefixCodes;

    partial class AsmBytes
    {
        // REX.W + B8+ rd io | MOV r64, imm64           | OI    | Valid       | N.E.            | Move imm64 to r64.                                             |
        [MethodImpl(Inline), Op]
        public static byte mov(r64 r, imm64 imm, Span<byte> dst)
            => encode(RexW, (Hex8)(0xb8 + (byte)r.Index), imm, dst);
    }
}