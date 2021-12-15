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
        const string ClassSubtypeQuery = "llvm/classes/subtypes";

        [CmdOp(ClassSubtypeQuery)]
        Outcome Subtypes(CmdArgs args)
        {
            var result = Outcome.Success;
            var defs = DataProvider.SelectDefRelations();
            var cname = arg(args,0).Value;
            var counter = 0u;
            var items = list<ListItem<Identifier>>();
            foreach(var def in defs)
            {
                var ancestors = def.Ancestors;
                if(ancestors.IsNonEmpty)
                {
                    if(ancestors.Name == cname)
                    {
                        items.Add((counter++,def.Name));
                        continue;
                    }
                    else
                    {
                        foreach(var a in ancestors.Ancestors)
                        {
                            if(a == cname)
                            {
                                items.Add((counter++, def.Name));
                                continue;
                            }
                        }
                    }
                }
            }

            DataEmitter.EmitQueryResults(ClassSubtypeQuery, cname, items.ViewDeposited());

            return result;
        }

        [CmdOp("llvm/emit/lineage")]
        Outcome EmitLineageSummary(CmdArgs args)
        {
            var result = Outcome.Success;
            var defrel = DataProvider.SelectDefRelations();
            var classrel = DataProvider.SelectClassRelations();

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