//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<string> SelectAsmMnemonicNames()
        {
            return (Index<string>)DataSets.GetOrAdd("AsmMnemonicNames", key => Load());

            Index<string> Load()
            {
                return SelectAsmVariations().Where(x => x.Mnemonic.IsNonEmpty).Map(x => x.Mnemonic.Format()).Distinct().Sort();
            }
        }
    }
}