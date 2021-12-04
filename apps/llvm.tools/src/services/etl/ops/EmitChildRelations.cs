//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmEtl
    {
        public FS.FilePath EmitChildRelations()
        {
            var src = DataProvider.SelectEntities();
            var parents = src.GroupByParent();
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

            var path = LlvmPaths.Table<ChildRelation>();
            TableEmit(dst.ViewDeposited(), path);
            return path;
        }
    }
}