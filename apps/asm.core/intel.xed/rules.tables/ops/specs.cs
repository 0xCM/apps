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
            public static Index<TableSpec> specs(RuleTableKind kind)
                => specs(XedPaths.Service.RuleSource(kind));

            public static Index<TableSpec> specs(FS.FilePath src)
            {
                var skip = hashset("XED_RESET");
                using var reader = src.Utf8LineReader();
                var counter = 0u;
                var dst = list<TableSpec>();
                var tkind = XedPaths.tablekind(src.FileName);
                var statements =list<RowSpec>();
                var name = EmptyString;
                while(reader.Next(out var line))
                {
                    if(XedParsers.RuleForm(line.Content) == RuleFormKind.SeqDecl)
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
                            if(!skip.Contains(name))
                                dst.Add(new (new (tkind, name), statements.ToArray()));

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
                        if(CellParser.parse(content, out RowSpec s))
                            statements.Add(s);
                    }
                }

                return merge(dst.ToArray());
            }
        }
    }
}