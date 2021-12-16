//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<string> SelectAsmMnemonicNames()
            => (Index<string>)DataSets.GetOrAdd(nameof(SelectAsmMnemonicNames), _ => DataCalcs.CalcAsmMnemonicNames(SelectAsmVariations()));
    }
}