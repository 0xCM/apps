//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataProvider
    {
        public Index<LlvmInstDef> SelectInstDefs()
        {
            return (Index<LlvmInstDef>)DataSets.GetOrAdd(nameof(SelectInstDefs), key => Load());

            Index<LlvmInstDef> Load()
            {
                return DataCalcs.CalcInstDefs(SelectAsmIdentifiers(), SelectEntities());
            }
        }

        public Index<LlvmInstDef> SelectInstDefs(AsmIdentifiers asmid, Index<LlvmEntity> entities)
            => (Index<LlvmInstDef>)DataSets.GetOrAdd(nameof(SelectInstDefs), key => DataCalcs.CalcInstDefs(asmid, entities));
    }
}