//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<DefRelations> SelectDefRelations()
        {
            return (Index<DefRelations>)DataSets.GetOrAdd(nameof(DefRelations), key => TableLoader.LoadDefRelations());
        }
    }
}