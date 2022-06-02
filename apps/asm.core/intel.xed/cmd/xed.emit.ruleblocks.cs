//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class AsmCoreCmd
    {
        Index<RuleTableBlock> EmitRuleBlocks(RuleTableKind kind)
        {
            var dst = text.emitter();
            var blocks = XedRules.blocks(kind);
            var count = blocks.Count;
            for(var i=0u; i<count; i++)
            {
                blocks[i].Render(i, dst);
                dst.AppendLine();
            }

            AppSvc.FileEmit(dst.Emit(), count, XedPaths.RuleTarget($"blocks.{kind.ToString().ToLower()}", FS.Csv));
            return blocks;

        }

        [CmdOp("xed/emit/ruleblocks")]
        void EmitRuleBlocks()
        {
            var names = hashset<string>();
            var enc = EmitRuleBlocks(RuleTableKind.ENC);
            iter(enc, table => names.Add(table.TableName));

            var dec = EmitRuleBlocks(RuleTableKind.DEC);
            iter(dec, table => names.Add(table.TableName));

            var known = Symbols.kinds<RuleName>().Where(x => x != 0).ToArray().Map(x => x.ToString()).ToHashSet();

            foreach(var name in names)
            {
                if(!known.Contains(name))
                    Write($"Not known: {name}");
            }
        }

    }
}