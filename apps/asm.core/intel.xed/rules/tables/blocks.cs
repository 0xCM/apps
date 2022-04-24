//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        partial struct TableCalcs
        {
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
                    if(i < names.Count - 1)
                    {
                        var i1 = offsets[i+1];
                        seek(dst,i) = new RuleTableBlock(kind, name, i0, core.segment(view, i0, i1 - 1).ToArray());
                    }
                    else
                        seek(dst,i) = new RuleTableBlock(kind, name, i0, core.slice(view, i0).ToArray());
                }

                return dst.Sort();
            }
        }
    }
}