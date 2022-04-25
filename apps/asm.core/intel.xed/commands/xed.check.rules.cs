//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static Char5;
    using static core;
    using static XedGrids;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var rules = CalcRules();
            var cells = Rules.CalcRuleCells(rules);
            ref readonly var tables = ref cells.Tables;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                for(var j=0; i<table.RowCount; j++)
                {
                    ref readonly var row = ref table[i];
                    for(var k=0; i<row.CellCount; k++)
                    {
                        ref readonly var cell = ref row[k];
                    }
                }
            }

            return true;
        }

        Outcome CheckSegVars(CmdArgs args)
        {
            var a = Code.A;
            var b = Code.B;
            var c = Code.C;
            var _ = Code._;
            var d = Code.D;


            var v0 = new SegVar(a, b, c, _, d);
            var v1 = new SegVar(Code.W, Code.R, Code.X, Code.B);
            Write(v0.Format());
            Write(v1.Format());

            var v2 = SegVar.parse("ss_ii_bbbb");
            Write(v2);

            return true;

        }

        [CmdOp("xed/emit/ruleblocks")]
        Outcome EmitRuleBlocks(CmdArgs args)
        {
            var known = Symbols.kinds<RuleName>().Where(x => x != 0).ToArray().Map(x => x.ToString()).ToHashSet();
            var found = hashset<string>();
            var dst = text.emitter();
            var blocks = CellParser.blocks();
            var count = blocks.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref blocks[i];
                var seq = string.Format("{0:D3}",i);
                var offset = string.Format("{0:D5}", block.Offset);
                found.Add(block.TableName);
                dst.AppendLine($"{seq} {block.TableKind} {string.Format(RP.slot(0,-32),block.TableName)} | {offset}");
            }

            FileEmit(dst.Emit(), count, XedPaths.RuleTarget("names", FS.Csv));

            foreach(var f in found)
            {
                if(!known.Contains(f))
                    Write($"Not known: {f}");
            }

            return true;
        }

    }
}