//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = ImmBitWidth;

    using static Pow2x8;

    [SymSource]
    public enum ImmKind : byte
    {
        None = 0,

        [Symbol("imm8")]
        Imm8 = W.W8,

        [Symbol("imm8i")]
        Imm8i = Imm8 | P2ᐞ07,

        [Symbol("imm16")]
        Imm16 = W.W16,

        [Symbol("imm16i")]
        Imm16i = Imm16 | P2ᐞ07,

        [Symbol("imm32")]
        Imm32 = W.W32,

        [Symbol("imm32i")]
        Imm32i = Imm32 | P2ᐞ07,

        [Symbol("imm64")]
        Imm64 = W.W32,

        [Symbol("imm64i")]
        Imm64i = Imm64 | P2ᐞ07
    }
}