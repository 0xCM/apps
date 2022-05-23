//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public ConstLookup<Identifier,EntityLineage> DefLineage()
            => (ConstLookup<Identifier,EntityLineage>)DataSets.GetOrAdd(nameof(DefLineage), key => DataCalcs.CalcDefLineage(DefRelations()));
    }
}