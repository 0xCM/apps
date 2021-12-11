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
        public Index<ChildRelation> EmitChildRelations()
        {
            var parents = RecordEntities.GroupByParent(DataProvider.SelectEntities());
            var dst = list<ChildRelation>();
            var counter = 0u;
            var key = 0u;
            var parentKey = 0u;
            foreach(var parent in parents.Values)
            {
                var relation = new ChildRelation();
                parentKey++;
                var seq = 0u;
                foreach(var child in parent.Members)
                {
                    relation.Key = key++;
                    relation.ParentKey = parentKey;
                    relation.ParentName = parent.Name;
                    relation.ChildName = child.EntityName;
                    relation.ChildSeq = seq++;
                    dst.Add(relation);
                }
            }

            var records = dst.Array();
            var path = LlvmPaths.Table<ChildRelation>();
            TableEmit(@readonly(records), path);
            return records;
        }
    }
}