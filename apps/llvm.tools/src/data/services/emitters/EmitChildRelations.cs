//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataEmitter
    {
        public Index<ChildRelation> EmitChildRelations(ReadOnlySpan<LlvmEntity> entities)
        {
            var records = DataCalcs.CalcChildRelations(entities);
            var path = LlvmPaths.Table<ChildRelation>();
            TableEmit(records.View, path);
            return records;
        }
    }
}