//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var rules = CalcRules();
            var lookup = CellParser.cells(rules);
            var tables = lookup.Tables;
            // var dst = text.emitter();
            // var count = CellRender.render(lookup,dst);
            // var data = Require.equal(dst.Emit(), lookup.Description);
            // FileEmit(data, count, XedPaths.RuleTarget("cells.raw", FS.Csv), TextEncodingKind.Asci);

            // var sigs = lookup.Keys;
            // var tables = sigs.ToArray().Map(x => lookup.Table(x)).Index().Sort();
            // for(var i=0; i<tables.Count; i++)
            // {
            //     ref readonly var table = ref tables[i];
            //     Write(table.Sig.Format());
            // }


            return true;
        }


        void LoadRuleBlocks()
        {
            var known = Symbols.kinds<RuleName>().Where(x => x != 0).ToArray().Map(x => x.ToString()).ToHashSet();
            var found = hashset<string>();
            var dst = text.emitter();
            var encBlocks = TableCalcs.blocks(RuleTableKind.ENC);
            var decBlocks  = TableCalcs.blocks(RuleTableKind.DEC);
            var blocks = (encBlocks + decBlocks).Sort();
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

        }
        void CheckNonTerms()
        {
            var patterns = CalcPatterns();
            var count = patterns.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var fields = ref pattern.Fields;
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    if(op.Nonterminal(out var nt))
                    {
                        Require.invariant(nt.IsNonEmpty);
                        GprWidth.widths(nt, out var widths);
                        Write(string.Format("{0,-18} | {1}={2,-24} | {3}", pattern.InstClass, op.Name, nt, widths), FlairKind.StatusData);
                    }

                }
            }
        }

        void CheckGprWidths()
        {
            var ntk = RuleName.GPR8_R;
            var result = GprWidth.widths(ntk, out var widths);
            Write(widths.Format());
        }

        bool Match(Index<string> a, Index<string> b)
        {
            var result = true;
            var count = a.Count;
            result = (count == b.Count);
            if(result)
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var x = ref a[i];
                    ref readonly var y = ref b[i];
                    result = x == y;
                    if(!result)
                        break;
                }
            }

            return result;
        }
    }
}