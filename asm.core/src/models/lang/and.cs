//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmMnemonicCode;
    using static AsmOperands;

    partial struct AsmLang
    {
        // 22 /r            | AND r8, r/m8     | RM    | Valid       | Valid           | r8 AND r/m8.                              |
        [Op]
        public AsmExpr and(r8 a0, r8 a1)
            => Produce(S[AND], S[a0], S[a1]);

        // | 23 /r            | AND r16, r/m16   | RM    | Valid       | Valid           | r16 AND r/m16.                            |
        [Op]
        public AsmExpr and(r16 a0, r16 a1)
            => Produce(S[AND], S[a0], S[a1]);

        // 80 /4 ib         | AND r/m8, imm8   | MI    | Valid       | Valid           | r/m8 AND imm8.
        [Op]
        public AsmExpr and(r8 a0, imm8 imm8)
            => Produce(S[AND], S[a0], imm8);
    }
}