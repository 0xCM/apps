//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static Root;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("members")]
        Outcome DefLineage(CmdArgs args)
        {
            var result = Outcome.Success;
            var defs = DataLoader.LoadDefRelations();
            var classes = LlvmRelations.equivalance(DataLoader.LoadClassRelations());
            var cname = arg(args,0).Value;
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

        [CmdOp("llvm/emit/lineage")]
        Outcome EmitLineageSummary(CmdArgs args)
        {
            var result = Outcome.Success;
            var defrel = DataLoader.LoadDefRelations();
            var classrel = DataLoader.LoadClassRelations();

            var dst = Data.Log("llvm.lineage");
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