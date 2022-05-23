//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmInstDef> InstDefs()
            => (Index<LlvmInstDef>)DataSets.GetOrAdd(nameof(InstDefs), key => DataCalcs.CalcInstDefs(AsmIdentifiers(), Entities()));
    }
}