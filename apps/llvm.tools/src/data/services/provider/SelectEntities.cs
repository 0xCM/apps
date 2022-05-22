//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataProvider
    {
        Index<LlvmEntity> CalcEntities(Index<DefRelations> relations, Index<RecordField> fields)
            => (Index<LlvmEntity>)DataSets.GetOrAdd("Entities", _ => DataCalcs.CalcEntities(relations, fields));

        public Index<LlvmEntity> SelectEntities(Func<LlvmEntity,bool> predicate)
            => SelectEntities().Where(predicate);

        public Index<LlvmEntity> SelectEntities(Index<DefRelations> relations, Index<RecordField> fields)
            => (Index<LlvmEntity>)CalcEntities(relations, fields);

        public Index<LlvmEntity> SelectEntities()
            => (Index<LlvmEntity>)CalcEntities(SelectDefRelations(), DefFields());
    }
}