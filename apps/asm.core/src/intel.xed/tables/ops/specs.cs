//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules;

    partial class XedRuleTables
    {
        public static void specs(in RuleTableRow src, char kind, HashSet<RuleCellSpec> dst)
        {
            var storage = 0ul;
            var count = RuleTableRow.ColCount/2;
            var i = kind == 'P' ? z8 : count;
            var k = z8;
            for(var j=0; j<count; j++, i++)
            {
                var cell = src[i];
                if(cell.IsNonEmpty)
                    dst.Add(cell.Spec);
            }
        }

        public static Index<RuleTableSpec> specs(FS.FilePath src)
        {
            using var reader = src.Utf8LineReader();
            var counter = 0u;
            var dst = list<RuleTableSpec>();
            var tkind = XedPaths.tablekind(src.FileName);
            var statements =list<StatementSpec>();
            var name = EmptyString;
            while(reader.Next(out var line))
            {
                if(form(line.Content) == RuleFormKind.SeqDecl)
                {
                    while(reader.Next(out line))
                        if(line.IsEmpty)
                            break;
                    continue;
                }

                var content = text.trim(text.despace(line.Content));
                if(text.empty(content) || text.begins(content, Chars.Hash))
                    continue;

                var k = text.index(content,Chars.Hash);
                if(k > 0)
                    content = text.trim(text.left(content,k));

                if(text.ends(content, "()::"))
                {
                    if(counter != 0)
                    {
                        if(!Skip.Contains(name))
                            dst.Add(new (sig(tkind, name), statements.ToArray()));

                        statements.Clear();
                    }

                    name = text.remove(content,"()::");
                    var i = text.index(name, Chars.Space);
                    if(i > 0)
                        name = text.right(name,i);
                    counter++;
                }
                else
                {
                    if(parse(content, out StatementSpec s))
                        statements.Add(s);
                }
            }

            return dst.ToArray().Sort();
        }
    }
}