//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public AsmIdentifiers SelectAsmIdentifiers()
            => (AsmIdentifiers)DataSets.GetOrAdd(nameof(SelectAsmIdentifiers), key => DataLoader.LoadAsmIdentifiers());
    }
}