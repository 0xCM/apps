//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmCmdProvider
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
    }
}