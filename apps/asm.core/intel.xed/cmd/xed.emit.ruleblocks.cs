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
        public static Index<RuleTableBlock> blocks()
            => (blocks(RuleTableKind.ENC) + blocks(RuleTableKind.DEC)).Sort();

        public static Index<RuleTableBlock> blocks(RuleTableKind kind)
        {
            var src = XedPaths.Service.RuleSource(kind);
            var lines = src.ReadLines();
            var offsets = list<uint>();
            var names = list<string>();
            for(var i=0u; i<lines.Count; i++)
            {
                var line = text.trim(text.despace(lines[i]));
                if(text.empty(line) || text.begins(line, Chars.Hash))
                    continue;

                var j = text.index(line,Chars.Hash);
                var content = (j > 0 ? text.left(line,j) : line).Trim();
                if(text.ends(content,"()::"))
                {
                    var k = text.index(content, Chars.LParen);
                    var name = text.left(content,k);
                    names.Add(name.Remove("xed_reg_enum_t").Trim());
                    offsets.Add(i);
                }
            }

            var dst = alloc<RuleTableBlock>(names.Count);
            var pos = 0;
            var view = lines.View;
            for(var i=0; i<names.Count; i++)
            {
                var name = names[i];
                var i0 = offsets[i];
                ref var target = ref seek(dst,i);
                if(i < names.Count - 1)
                {
                    var i1 = offsets[i+1];
                    var seg = core.segment(view, i0, i1 - 1);
                    var parts = list<string>();
                    for(var j=0; j<seg.Length; j++)
                    {
                        var part = text.trim(text.despace(skip(seg,j)));
                        if(text.empty(part) || text.begins(part,Chars.Hash) || text.ends(part, "::") || text.ends(part, "()") || text.begins(part, "SEQUENCE "))
                            continue;

                        var k = text.index(part,Chars.Hash);
                        if(k>0)
                            parts.Add(text.left(part,k));
                        else
                            parts.Add(part);
                    }
                    target = new RuleTableBlock(kind, name, i0, parts.ToArray());

                }
                else
                {
                    var seg = core.slice(view, i0);
                    var parts = list<string>();
                    for(var j=0; j<seg.Length; j++)
                    {
                        var part = text.trim(text.despace(skip(seg,j)));
                        if(text.empty(part) || text.begins(part,Chars.Hash))
                            continue;
                        parts.Add(part);
                    }
                    target = new RuleTableBlock(kind, name, i0, parts.ToArray());
                }
            }

            return dst.Sort();
        }

        [CmdOp("xed/emit/ruleblocks")]
        Outcome EmitRuleBlocks(CmdArgs args)
        {
            var known = Symbols.kinds<RuleName>().Where(x => x != 0).ToArray().Map(x => x.ToString()).ToHashSet();
            var found = hashset<string>();
            var dst = text.emitter();
            var _blocks = blocks();
            var count = _blocks.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref _blocks[i];
                var seq = string.Format("{0:D3}",i);
                var offset = string.Format("{0:D5}", block.Offset);
                found.Add(block.TableName);
                dst.AppendLine($"{seq} {block.TableKind} {string.Format(RP.slot(0,-32),block.TableName)} | {offset}");
                for(var j=0; j<block.Data.Count; j++)
                {
                    dst.IndentLine(12, block.Data[j]);
                }
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