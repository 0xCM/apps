//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<ClassRelations> ClassRelations()
            => (Index<ClassRelations>)DataSets.GetOrAdd(nameof(llvm.ClassRelations), key => DataLoader.LoadClassRelations());
    }
}