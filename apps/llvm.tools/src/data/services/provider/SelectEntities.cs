//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataProvider
    {
        public Index<LlvmEntity> SelectEntities(Func<LlvmEntity,bool> predicate)
            => SelectEntities().Where(predicate);

        public Index<LlvmEntity> SelectEntities(Index<DefRelations> relations, Index<RecordField> fields)
            => (Index<LlvmEntity>)DataSets.GetOrAdd("Entities", key => DataCalcs.CalcEntities(relations, fields));

        public Index<LlvmEntity> SelectEntities()
        {
            return (Index<LlvmEntity>)DataSets.GetOrAdd("Entities", key => Load());

            Index<LlvmEntity> Load()
            {
                var relations = SelectDefRelations();
                var src = SelectDefFields().View;
                return DataCalcs.CalcEntities(relations,src);
            }
        }
    }
}