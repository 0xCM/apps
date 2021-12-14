//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<ClassRelations> SelectClassRelations()
            => (Index<ClassRelations>)DataSets.GetOrAdd(nameof(ClassRelations), key => TableLoader.LoadClassRelations());
    }
}