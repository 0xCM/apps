//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public RegIdentifiers SelectRegIdentifiers()
            => (RegIdentifiers)DataSets.GetOrAdd(nameof(SelectRegIdentifiers), _ => DataLoader.LoadRegIdentifiers());
    }
}