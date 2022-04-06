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

            public static Index<TableDefRow> CalcDefRows(Index<RuleTableSpec> src)
            {
                var count = src.Storage.Map(x => x.StatementCount).Sum();
                var dst = alloc<TableDefRow>(count);
                var n=0u;
                for(var i=0u; i<src.Count; i++)
                    CalcDefRows(src[i], ref n, dst);
                return dst;
            }

            public static Index<RuleTableSpec> CalcTableSpecs(RuleTableKind kind)
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

            public static RuleExprLookup CalcExprLookup(RuleTables rules)
            {
                var dst = dict<RuleExprKey,CellDef>();
                CalcExprLookup(rules.EncTableSpecs(), dst);
                CalcExprLookup(rules.DecTableSpecs(), dst);
                return dst;
            }

            public static void CalcExprLookup(Index<RuleTableSpec> src, Dictionary<RuleExprKey,CellDef> dst)
            {
                for(var i=0; i<src.Count; i++)
                    CalcExprLookup(src[i], dst);
            }

            static void CalcExprLookup(in RuleTableSpec src, Dictionary<RuleExprKey,CellDef> dst)
            {
                for(var i=z16; i<src.StatementCount; i++)
                    CalcExprLookup(i, src, dst);
            }

            static void CalcExprLookup(ushort row, in RuleTableSpec table, Dictionary<RuleExprKey,CellDef> dst)
            {
                CalcExprLookup(row, table, 'P', table[row].Premise, dst);
                CalcExprLookup(row, table, 'C', table[row].Consequent, dst);
            }

            static void CalcExprLookup(ushort row, in RuleTableSpec table, char logic, Index<CellSpec> src, Dictionary<RuleExprKey,CellDef> dst)
            {
                for(var i=z8; i<src.Count; i++)
                {
                    var key = new RuleExprKey(table.Sig.TableKind, table.TableId, row, logic, i);
                    var expr = src[i].Expr();
                    if(!dst.TryAdd(key, expr))
                        Errors.Throw(string.Format("Duplicate:({0},'{1}')", key, expr));
                }
            }

            public static Index<RuleTableSpec> CalcTableSpecs(FS.FilePath src)
            {
                var skip = hashset("XED_RESET");
                using var reader = src.Utf8LineReader();
                var counter = 0u;
                var dst = list<RuleTableSpec>();
                var tkind = XedPaths.tablekind(src.FileName);
                var statements =list<StatementSpec>();
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
                        if(CellParser.parse(content, out StatementSpec s))
                            statements.Add(s);
                    }
                }

                return merge(dst.ToArray());
            }

            static uint CalcDefRows(in RuleTableSpec spec, ref uint n, Span<TableDefRow> dst)
            {
                var i0 = n;
                for(var j=0u; j<spec.StatementCount; j++, n++)
                {
                    ref var row = ref seek(dst,n);
                    var k=z8;
                    row.TableId = spec.TableId;
                    row.Kind = spec.Sig.TableKind;
                    row.Name = spec.Sig.ShortName;
                    row.Seq = n;
                    row.Index = j;

                    var statement = RuleGridCells.Empty;

                    ref readonly var antecedant = ref spec[j].Premise;
                    for(var m=0; m<antecedant.Count; m++,k++)
                        statement[k] = new (true, k, spec.Sig.TableKind, criterion(antecedant[m]));

                    ref readonly var consequent = ref spec[j].Consequent;
                    if(consequent.Count != 0)
                    {
                        statement[k] = new (true,k, spec.Sig.TableKind, OperatorKind.Impl);
                        k++;
                    }

                    for(var m=0; m<consequent.Count; m++,k++)
                        statement[k] = new (false, k, spec.Sig.TableKind, criterion(consequent[m]));

                    statement.Count = k;
                    row.Statement = statement;
                }

                return n - i0;
            }

            static Index<RuleTableSpec> merge(Index<RuleTableSpec> src)
            {
                var dst = dict<RuleSig,RuleTableSpec>(src.Count);
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

            static Index<RuleTable> reify(ReadOnlySpan<RuleTableSpec> src)
            {
                var dst = alloc<RuleTable>(src.Length);
                for(var i=0; i<src.Length; i++)
                    seek(dst,i) = reify(skip(src,i));
                return dst;
            }

            static RuleTable reify(RuleTableSpec src)
            {
                var body = list<RuleStatement>();
                for(var i=0; i<src.Statements.Count; i++)
                {
                    ref readonly var stmt = ref src.Statements[i];
                    if(stmt.IsNonEmpty)
                        body.Add(reify(stmt));
                }
                return new (src.Sig, body.ToArray());
            }

            static RuleStatement reify(StatementSpec src)
            {
                var left = sys.empty<RuleCriterion>();
                if(src.Premise.IsNonEmpty)
                    left = criteria(src.Premise.View);

                var right = sys.empty<RuleCriterion>();
                if(src.Consequent.IsNonEmpty)
                    right = criteria(src.Consequent.View);

                return new RuleStatement(left, right);
            }

        }
   }
}