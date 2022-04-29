//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
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