//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmInstDef> SelectInstDefs()
            => (Index<LlvmInstDef>)DataSets.GetOrAdd(nameof(SelectInstDefs), key => DataCalcs.CalcInstDefs(SelectAsmIdentifiers(), SelectEntities()));

        // public Index<LlvmInstDef> InstDefs(AsmIdentifiers asmid, Index<LlvmEntity> entities)
        //     => (Index<LlvmInstDef>)DataSets.GetOrAdd("inst.defs." + asmid, key => DataCalcs.CalcInstDefs(asmid, entities));
    }
}