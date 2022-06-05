//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    partial class LlvmDataProvider
    {
        public Index<AsmMnemonicRow> Mnemonics()
            => (Index<AsmMnemonicRow>)DataSets.GetOrAdd(nameof(Mnemonics), _ => DataCalcs.CalcAsmMnemonics(AsmVariations()));
    }
}