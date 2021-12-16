//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ConstLookup<Identifier,EntityLineage> SelectDefLineage()
            => (ConstLookup<Identifier,EntityLineage>)DataSets.GetOrAdd(nameof(SelectDefLineage), key => DataCalcs.CalcDefLineage(SelectDefRelations()));
    }
}