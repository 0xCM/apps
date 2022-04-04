//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataProvider
    {
        public Index<DefRelations> SelectDefRelations(Func<DefRelations,bool> predicate)
        {
            var relations = SelectDefRelations();
            var count = relations.Count;
            var dst = hashset<DefRelations>();
            for(var i=0; i<count; i++)
            {
                ref readonly var relation = ref relations[i];
                ref readonly var child = ref relation.Name;
                var ancestors = relation.AncestorNames;
                if(ancestors.Length != 0 && predicate(relation))
                    dst.Add(relation);
            }

            return dst.Array().Sort();
        }

        public Index<Dependency<string>> SelectDefRelationArrows()
        {
            return (Index<Dependency<string>>)DataSets.GetOrAdd(nameof(SelectDefRelationArrows), key => Load());

            Index<Dependency<string>> Load()
            {
                var relations = SelectDefRelations();
                var count = relations.Count;
                var dst = hashset<Dependency<string>>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var relation = ref relations[i];
                    ref readonly var child = ref relation.Name;
                    var ancestors = relation.AncestorNames;
                    if(ancestors.Length != 0)
                        dst.Add((child, first(ancestors)));
                }

                return dst.Array().Sort();
            }
        }
    }
}