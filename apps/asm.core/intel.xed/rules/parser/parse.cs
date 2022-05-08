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
        partial struct CellParser
        {
            public static Index<TableCriteria> criteria(RuleTableKind kind)
                => parse(XedPaths.Service.RuleSource(kind));

            public static Index<TableCriteria> parse(FS.FilePath src)
            {
                var skip = hashset("XED_RESET");
                using var reader = src.Utf8LineReader();
                var counter = 0u;
                var dst = list<TableCriteria>();
                var tkind = XedPaths.tablekind(src.FileName);
                var statements =list<RowCriteria>();
                var name = EmptyString;
                while(reader.Next(out var line))
                {
                    if(RuleForm(line.Content) == RuleFormKind.SeqDecl)
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
                            {
                                XedParsers.parse(name, out RuleName rn);
                                dst.Add(new (new (tkind,rn), statements.ToArray()));
                            }

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
                        if(CellParser.criteria(content, out RowCriteria s))
                            statements.Add(s);
                    }
                }

                return merge(dst.ToArray());
            }

            public static bool criteria(string src, out RowCriteria dst)
            {
                var input = normalize(src);
                var i = text.index(input,"=>");
                dst = RowCriteria.Empty;
                if(i > 0)
                {
                    var left = text.trim(text.left(input, i));
                    var premise = text.nonempty(left) ? cells(left) : Index<CellInfo>.Empty;
                    var right = text.trim(text.right(input, i+1));
                    var consequent = text.nonempty(right) ? cells(right) : Index<CellInfo>.Empty;
                    if(premise.Count != 0 || consequent.Count != 0)
                        dst = new RowCriteria(premise, consequent);
                }
                else
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RowCriteria), src));

                return dst.IsNonEmpty;
            }

            static Index<CellInfo> cells(string src)
            {
                var input = text.trim(text.despace(src));
                var cells = list<string>();
                if(text.contains(input, Chars.Space))
                {
                    var parts = text.split(input, Chars.Space);
                    var count = parts.Length;
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var part = ref skip(parts,j);
                        if(RuleMacros.match(part, out var match))
                        {
                            var expanded = text.trim(match.Expansion);
                            if(text.contains(expanded, Chars.Space))
                            {
                                var expansions = text.split(expanded, Chars.Space);
                                for(var k=0; k<expansions.Length; k++)
                                    cells.Add(skip(expansions, k));
                            }
                            else
                                cells.Add(expanded);
                        }
                        else
                            cells.Add(part);
                    }
                }
                else
                {
                    if(RuleMacros.match(input, out var match))
                        cells.Add(match.Expansion);
                    else
                        cells.Add(input);
                }

                return cells.Map(cellinfo);
            }

            static CellInfo cellinfo(string src)
            {
                parse(src, out CellTypeInfo t);
                return XedRules.cellinfo(t, LogicKind.None, src);
            }

            static string normalize(string src)
            {
                var dst = EmptyString;
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    dst = text.despace(text.trim(text.left(src, i)));
                else
                    dst = text.despace(text.trim(src));

                return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
            }
        }
    }
}