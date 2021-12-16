//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<DefRelations> SelectDefRelations()
            => (Index<DefRelations>)DataSets.GetOrAdd(nameof(DefRelations), key => DataLoader.LoadDefRelations());
    }
}