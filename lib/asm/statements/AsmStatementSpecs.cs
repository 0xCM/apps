//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public struct AsmStatementSpec
    {
        public AsmMnemonic Mnemonic;

        public Index<AsmOpVar> Operands;
    }
}