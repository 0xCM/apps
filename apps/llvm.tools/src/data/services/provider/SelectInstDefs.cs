//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmInstDef> SelectInstDefs()
            => (Index<LlvmInstDef>)DataSets.GetOrAdd(nameof(SelectInstDefs), key => DataCalcs.CalcInstDefs(AsmIdentifiers(), SelectEntities()));
    }
}