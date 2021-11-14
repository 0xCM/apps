//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using records;

    using static Root;
    using static core;
    using static LlvmNames.Queries;

    using Eq = Equivalence;

    partial class LlvmCmd
    {
        [CmdOp(lineage)]
        Outcome SummarizeLineage(CmdArgs args)
        {
            var result = Outcome.Success;
            var defrel = Db.DefRelations();
            var classrel = Db.ClassRelations();

            var dst = Data.Log(lineage);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();

            iter(classrel, r => {
                if(r.Ancestors.IsNonEmpty)
                    writer.WriteLine(string.Format("{0} -> {1}", r.Name, r.Ancestors));
                else
                    writer.WriteLine(r.Name);
            });

            iter(defrel, r => {
                if(r.Ancestors.IsNonEmpty)
                    writer.WriteLine(string.Format("{0} -> {1}", r.Name, r.Ancestors));
                else
                    writer.WriteLine(r.Name);
            });

            iter(EqClassMembers(classrel), c => Write(c.Format()));

            EmittedFile(emitting, classrel.Length + defrel.Length);

            return result;
        }

        static ReadOnlySpan<Eq.ClassMember> EqClassMembers(ReadOnlySpan<ClassRelations> src)
        {
            var count = (uint)src.Length;
            var classes = Eq.lookup();
            var ancestors = dict<Eq.Class,string>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var relation = ref skip(src,i);
                var @class = new Eq.Class(i, relation.Name);

                if(!classes.Include(@class))
                    continue;

                if(relation.HasAncestor)
                    ancestors[@class] = relation.Ancestors.Name;
            }

            var members = list<Eq.ClassMember>();
            var indexed = classes.Seal();
            for(var i=0u; i<indexed.Length; i++)
            {
                ref readonly var child = ref skip(indexed,i);
                if(ancestors.TryGetValue(child, out var a))
                {
                    if(classes.Find(a, out var parent))
                        members.Add(new Eq.ClassMember(parent, child.ClassId, child.ClassName));
                }
            }

            return members.ViewDeposited();
        }
    }
}