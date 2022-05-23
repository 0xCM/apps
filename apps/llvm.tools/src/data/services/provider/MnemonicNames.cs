//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<string> MnemonicNames()
            => (Index<string>)DataSets.GetOrAdd(nameof(MnemonicNames), _ => DataCalcs.CalcAsmMnemonicNames(AsmVariations()));
    }
}