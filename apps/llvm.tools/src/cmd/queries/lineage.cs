//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static Root;
    using static core;
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp("members")]
        Outcome DefLineage(CmdArgs args)
        {
            var result = Outcome.Success;
            var defs = RecordLoader.LoadDefRelations();
            var classes = LlvmRelations.equivalance(RecordLoader.LoadClassRelations());
            var cname = "DAGOperand";
            var @class = classes.Where(c => c.MemberName == cname);
            var counter = 0u;
            foreach(var def in defs)
            {
                var ancestors = def.Ancestors;
                if(ancestors.IsNonEmpty)
                {
                    if(ancestors.Name == cname)
                    {
                        var literal = string.Format("{0}={1},", def.Name, counter++);
                        Write(literal);
                        continue;
                    }
                    else
                    {
                        foreach(var a in ancestors.Ancestors)
                        {
                            if(a == cname)
                            {
                                var literal = string.Format("{0}={1},", def.Name, counter++);
                                Write(literal);
                                continue;
                            }
                        }
                    }
                }
            }

            return result;
        }

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

            iter(LlvmRelations.equivalance(classrel), c => Write(c.Format()));

            EmittedFile(emitting, classrel.Length + defrel.Length);

            return result;
        }
    }
}