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
        public readonly struct RuleSpecs
        {
            [MethodImpl(Inline)]
            public static CellInfo cellinfo(in CellTypeInfo type, LogicClass logic, string data)
                => new CellInfo(type, logic, data);

            [MethodImpl(Inline)]
            public static CellInfo cellinfo(RuleOperator op)
                => new CellInfo(op);

            public static Index<TableCriteria> criteria(RuleTableKind kind)
                => criteria(XedPaths.Service.RuleSource(kind));

            public static Index<TableCriteria> criteria(FS.FilePath src)
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
                    if(CellParser.RuleForm(line.Content) == RuleFormKind.SeqDecl)
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
                        if(criteria(content, out RowCriteria s))
                            statements.Add(s);
                    }
                }

                return CellParser.merge(dst.ToArray());
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
                CellParser.parse(src, out CellTypeInfo t);
                return RuleSpecs.cellinfo(t, LogicKind.None, src);
            }

            public static string normalize(string src)
            {
                var dst = EmptyString;
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    dst = text.despace(text.trim(text.left(src, i)));
                else
                    dst = text.despace(text.trim(src));

                return dst.Replace("->", "=>").Replace("|", "=>").Remove("XED_RESET");
            }

            public static TableSpecs tables(Index<TableCriteria> src)
            {
                var dst = dict<RuleSig,TableSpec>();
                var specs = alloc<TableSpec>(src.Count);
                var seq = z16;
                for(var i=z16; i<src.Count; i++)
                {
                    ref readonly var table = ref src[i];
                    var tix = i;
                    var tk = table.TableKind;
                    ref readonly var sig = ref table.Sig;
                    var rows = alloc<RowSpec>(table.RowCount);
                    for(ushort j=0; j<table.RowCount; j++)
                    {
                        var rix = j;
                        ref readonly var row = ref table[j];
                        var left = row.Antecedant.Select(x => RuleSpecs.cellinfo(x.TypeInfo, LogicKind.Antecedant, x.Data));
                        var right = row.Consequent.Select(x => RuleSpecs.cellinfo(x.TypeInfo, LogicKind.Consequent, x.Data));
                        var count = left.Count + 1 + right.Count;
                        var keys = alloc<CellKey>(count);
                        var cells = alloc<CellInfo>(count);
                        var m=z8;
                        var kw = RuleKeyword.Empty;
                        for(var k=0; k<left.Count; k++,m++)
                        {
                            ref readonly var ci = ref left[k];
                            if(ci.IsKeyword)
                                XedParsers.parse(ci.Data, out kw);
                            seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Antecedant, left[k].Kind, tk, sig.TableName, left[k].Field, kw.KeywordKind);
                            seek(cells, m) = ci;
                        }

                        {
                            seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Operator, RuleCellKind.Operator, tk, sig.TableName, FieldKind.INVALID, KeywordKind.None);
                            seek(cells, m) = RuleSpecs.cellinfo(OperatorKind.Impl);
                            m++;
                        }

                        for(var k=0; k<right.Count; k++,m++)
                        {
                            ref readonly var ci = ref right[k];
                            if(ci.IsKeyword)
                                XedParsers.parse(ci.Data, out kw);
                            seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Consequent, right[k].Kind, tk, sig.TableName, right[k].Field, kw.KeywordKind);
                            seek(cells, m) = ci;
                        }
                        seek(rows,j) = new RowSpec(sig, tix, rix, keys, cells);
                    }

                    var spec = new TableSpec(tix, sig, rows);
                    seek(specs,i) = spec;
                    dst.Add(sig, spec);
                }
                return specs.Select(x => (x.Sig,x)).ToDictionary();
            }

        }
    }
}