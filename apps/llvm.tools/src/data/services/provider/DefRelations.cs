//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<DefRelations> DefRelations()
            => (Index<DefRelations>)DataSets.GetOrAdd(nameof(llvm.DefRelations), key => DataLoader.LoadDefRelations());
    }
}