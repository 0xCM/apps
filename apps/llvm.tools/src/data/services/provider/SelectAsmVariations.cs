//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmAsmVariation> SelectAsmVariations()
            => (Index<LlvmAsmVariation>)DataSets.GetOrAdd(nameof(SelectAsmVariations), _ => DataLoader.LoadAsmVariations());
    }
}