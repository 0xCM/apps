//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

    partial class LlvmDataEmitter
    {
        public Index<LlvmAsmVariation> EmitAsmVariations()
        {
            var entities = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var records = DataCalcs.CalcAsmVariations(DataProvider.DiscoverAsmIdentifiers(), entities);
            TableEmit(records.View, LlvmPaths.Table<LlvmAsmVariation>());
            return records;
        }
    }
}