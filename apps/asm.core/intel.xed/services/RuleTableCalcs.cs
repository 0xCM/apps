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

        // RuleTableSpec 1 -- * StatementSpec 1 -- * RuleCellSpec
        // RuleCellSpec -> RuleCriterion
        // RuleCellSpec -> RuleCellExpr

        public readonly struct RuleTableCalcs
        {
            public static Index<RuleSigRow> CalcSigRows(ConcurrentDictionary<RuleTableKind,Index<RuleTable>> src)
            {
                var sigs = src.Values.Array().SelectMany(x => x).Select(x => x.Sig).Distinct().Sort();
                var dst = alloc<RuleSigRow>(sigs.Length);
                for(var i=0u; i<sigs.Length; i++)
                {
                    ref var row = ref seek(dst,i);
                    ref readonly var sig = ref skip(sigs,i);
                    row.Seq = i;
                    row.TableKind = sig.TableKind;
                    row.TableName = sig.ShortName;
                    row.TableDef = XedPaths.Service.TableDef(sig);
                }
                return dst;
            }

            public static Index<RuleSeq> CalcRuleSeq()
                => XedParsers.ruleseq(XedPaths.Service.DocSource(XedDocKind.RuleSeq));

            public static Index<RuleTable> CalcTableDefs(RuleTableKind kind)
                => reify(CalcTableSpecs(XedPaths.Service.RuleSource(kind)));

            public static Index<TableDefRow> CalcDefRows(Index<CellTableSpec> src)
            {
                var count = src.Storage.Map(x => x.RowCount).Sum();
                var dst = alloc<TableDefRow>(count);
                var n=0u;
                for(var i=0u; i<src.Count; i++)
                    CalcDefRows(src[i], ref n, dst);
                return dst;
            }

            public static Index<CellTableSpec> CalcTableSpecs(RuleTableKind kind)
                => CalcTableSpecs(XedPaths.Service.RuleSource(kind));

            public static Index<RuleCriterion> criteria(ReadOnlySpan<CellSpec> src)
            {
                var dst = list<RuleCriterion>();
                var parts = map(src, p => p.Data);
                for(var i=0; i<parts.Length; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    var result = CellParser.parse(part, out RuleCriterion c);
                    if(result)
                        dst.Add(c);
                    else
                        Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), part));
                }
                return dst.ToArray();
            }

            public static Index<CellTableSpec> CalcTableSpecs(FS.FilePath src)
            {
                var skip = hashset("XED_RESET");
                using var reader = src.Utf8LineReader();
                var counter = 0u;
                var dst = list<CellTableSpec>();
                var tkind = XedPaths.tablekind(src.FileName);
                var statements =list<CellRowSpec>();
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
                        if(CellParser.parse(content, out CellRowSpec s))
                            statements.Add(s);
                    }
                }

                return merge(dst.ToArray());
            }

            static uint CalcDefRows(in CellTableSpec spec, ref uint n, Span<TableDefRow> dst)
            {
                var i0 = n;
                for(var j=0u; j<spec.RowCount; j++, n++)
                {
                    ref var row = ref seek(dst,n);
                    var k=z8;
                    row.Seq = n;
                    row.TableId = spec.TableId;
                    row.Index = j;
                    row.Kind = spec.Sig.TableKind;
                    row.Name = spec.Sig.ShortName;
                    row.Statement = spec[j].Format();
                }

                return n - i0;
            }

            static Index<CellTableSpec> merge(Index<CellTableSpec> src)
            {
                var dst = dict<RuleSig,CellTableSpec>(src.Count);
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var table = ref src[i];
                    ref readonly var sig = ref table.Sig;
                    if(sig.IsEmpty)
                        continue;

                    if(dst.TryGetValue(sig, out var t))
                        dst[sig] = t.Merge(table);
                    else
                    {
                        if(!dst.TryAdd(sig,table))
                            Errors.Throw(string.Format("Duplicate sig {0}", sig));
                    }

                }

                var specs = dst.Values.Array().Sort();
                for(var i=0u; i<specs.Length; i++)
                    seek(specs,i)= seek(specs,i).WithId(i);
                return specs;
            }

            static Index<RuleTable> reify(ReadOnlySpan<CellTableSpec> src)
            {
                var dst = alloc<RuleTable>(src.Length);
                for(var i=0; i<src.Length; i++)
                    seek(dst,i) = reify(skip(src,i));
                return dst;
            }

            static RuleTable reify(CellTableSpec src)
            {
                var body = list<RuleStatement>();
                for(var i=0; i<src.Rows.Count; i++)
                {
                    ref readonly var stmt = ref src.Rows[i];
                    if(stmt.IsNonEmpty)
                        body.Add(reify(stmt));
                }
                return new (src.Sig, body.ToArray());
            }

            static RuleStatement reify(CellRowSpec src)
            {
                var left = sys.empty<RuleCriterion>();
                if(src.Antecedant.IsNonEmpty)
                    left = criteria(src.Antecedant.View);

                var right = sys.empty<RuleCriterion>();
                if(src.Consequent.IsNonEmpty)
                    right = criteria(src.Consequent.View);

                return new RuleStatement(left, right);
            }
        }
   }
}