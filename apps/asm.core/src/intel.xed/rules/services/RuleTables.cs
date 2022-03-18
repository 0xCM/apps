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
        public class XedRuleTables : AppService<XedRuleTables>
        {
            public static RuleTableRows rows(in RuleTable src)
            {
                const byte ColCount = RuleTableRow.ColCount;

                var dst = list<RuleTableRow>();
                var q = 0u;
                for(var i=0u; i<src.Body.Count; i++)
                {
                    ref readonly var expr = ref src.Body[i];
                    if(expr.IsEmpty || expr.IsVacuous || expr.IsNull || expr.IsError)
                        continue;

                    var m = z8;
                    var row = RuleTableRow.Empty;
                    row.TableKind = src.TableKind;
                    row.TableName = src.Sig.Name;
                    row.RowIndex = q++;

                    for(var k=0; k<expr.Premise.Count; k++)
                        assign(m++, expr.Premise[k], ref row);

                    m = ColCount/2;

                    for(var k=0; k<expr.Consequent.Count; k++)
                        assign(m++, expr.Consequent[k], ref row);

                    dst.Add(row);
                }
                return new RuleTableRows(src.Sig,  dst.ToArray());
            }

            [MethodImpl(Inline), Op]
            static void assign(byte i, in RuleCriterion src, ref RuleTableRow dst)
                => dst[i] = new RuleTableCell(i,src);

            XedPaths XedPaths => Service(Wf.XedPaths);

            AppDb AppDb => Service(Wf.AppDb);

            bool PllWf = true;

            ConcurrentSet<RuleSig> TableSigs {get;} = new();

            ConcurrentDictionary<RuleSig,RuleSchema> Schemas {get;} = new();

            public void EmitTables(bool pll)
            {
                PllWf = pll;
                XedPaths.RuleTables().Clear();
                TableSigs.Clear();
                Schemas.Clear();
                exec(PllWf,
                    EmitDecTables,
                    EmitEncTables,
                    EmitEncDecTables,
                    EmitRuleSchemas,
                    EmitRuleSeq
                    );
                EmitSigs();
            }

            public Index<RuleSchema> CalcRuleSchemas()
            {
                var dst = bag<RuleSchema>();
                exec(PllWf,
                    () => CalcRuleSchemas(CalcTableDefs(RuleTableKind.Enc).Values, dst),
                    () => CalcRuleSchemas(CalcTableDefs(RuleTableKind.Dec).Values, dst),
                    () => CalcRuleSchemas(CalcTableDefs(RuleTableKind.EncDec).Values, dst)
                    );
                return dst.Array().Sort();
            }

            public void EmitRuleSchemas()
            {
                var schemas = CalcRuleSchemas();
                var count = 0u;
                iter(schemas, s => count += s.Cols.Count);
                var buffer = alloc<RuleSchemaRecord>(count);
                var k = 0u;
                foreach(var schema in schemas)
                {
                    var sig = schema.Sig;
                    var i=z8;
                    foreach(var col in schema.Cols)
                    {
                        ref var dst = ref seek(buffer,k);
                        dst.Seq = k;
                        dst.ColKind = col.Premise ? 'P' : 'C';
                        dst.TableName = schema.Sig.Name;
                        dst.Index = i++;
                        dst.TableField = col.Field;
                        dst.TableKind = schema.Sig.TableKind;
                        dst.Nonterm = col.Nonterm;
                        dst.TableDef = XedPaths.TableDef(sig);
                        k++;
                    }
                }

                TableEmit(@readonly(buffer), RuleSchemaRecord.RenderWidths, AppDb.XedTable<RuleSchemaRecord>("rules.tables"));
            }

            public Index<RuleSigRow> CalcSigRows()
            {
                var src = TableSigs.Members.Array().Sort();
                var count = src.Length;
                var dst = alloc<RuleSigRow>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var sig = ref skip(src,i);
                    ref var row = ref seek(dst,i);
                    row.Seq = i;
                    row.TableKind = sig.TableKind;
                    row.RuleClass = sig.Class;
                    row.TableName = sig.Name;
                    row.TableDef = XedPaths.TableDef(sig).ToUri();
                }
                return dst;
            }

            public RuleTableDefs CalcTableDefs(RuleTableKind kind)
                => kind switch{
                    RuleTableKind.Enc => CalcEncTableDefs(),
                    RuleTableKind.Dec => CalcDecTableDefs(),
                    RuleTableKind.EncDec => CalcEncDecTableDefs(),
                    _ => RuleTableDefs.Empty
                };

            public Index<RuleTableRow> CalcTableRows(in RuleTable src)
                => rows(src).Data;

            void EmitEncTables()
            {
                var buffer = bag<RuleTableRow>();
                void Collect(Index<RuleTableRow> src)
                {
                    for(var i=0; i<src.Count; i++)
                        buffer.Add(src[i]);
                }

                var src = CalcTableDefs(RuleTableKind.Enc);
                iter(src.Values, t => Collect(EmitTableDef("rules.tables/enc", t)), PllWf);
                EmitDescriptions(RuleTableKind.Enc, src);
                EmitConsolidated(buffer.Array().Sort());
            }

            void EmitDecTables()
            {
                var buffer = bag<RuleTableRow>();
                void Collect(Index<RuleTableRow> src)
                {
                    for(var i=0; i<src.Count; i++)
                        buffer.Add(src[i]);
                }

                var src = CalcTableDefs(RuleTableKind.Dec);
                iter(src.Values, t => Collect(EmitTableDef("rules.tables/dec", t)), PllWf);
                EmitDescriptions(RuleTableKind.Dec, src);
                EmitConsolidated(buffer.Array().Sort());
            }

            void EmitEncDecTables()
            {
                var buffer = bag<RuleTableRow>();
                void Collect(Index<RuleTableRow> src)
                {
                    for(var i=0; i<src.Count; i++)
                        buffer.Add(src[i]);
                }

                var src = CalcTableDefs(RuleTableKind.EncDec);
                iter(src.Values, t => Collect(EmitTableDef("rules.tables/encdec", t)), PllWf);
                EmitDescriptions(RuleTableKind.EncDec, src);
                EmitConsolidated(buffer.Array().Sort());
            }

            void EmitSigs()
                => TableEmit(CalcSigRows().View, RuleSigRow.RenderWidths, XedPaths.TableSigs());

            public Index<RuleSeq> CalcRuleSeq()
                => new RuleSeqParser().Parse(XedPaths.DocSource(XedDocKind.RuleSeq));

            public void EmitRuleSeq()
            {
                var src = CalcRuleSeq();
                var dst = text.buffer();
                iter(src, x => dst.AppendLine(x.Format()));
                FileEmit(dst.Emit(), src.Count, XedPaths.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
            }

            Index<RuleTableRow> EmitTableDef(string scope, in RuleTable src)
            {
                var data = rows(src).Data;
                if(data.IsNonEmpty)
                {
                    var specs = hashset<RuleCellSpec>();
                    ref readonly var sig = ref src.Sig;
                    Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];
                    RuleTableRow.RenderWidths(sig, data, widths);
                    var path = XedPaths.TableDef(sig);
                    var formatter = Z0.Tables.formatter<RuleTableRow>(widths);
                    using var writer = path.AsciWriter();
                    writer.AppendLine(formatter.FormatHeader());
                    var count = data.Count;
                    for(var i=0; i<count; i++)
                    {
                        ref readonly var row = ref data[i];
                        writer.AppendLine(formatter.Format(row));
                    }

                    writer.AppendLine();

                    var desc = src.Format().Lines(trim:false);
                    for(var i=0; i<desc.Length; i++)
                        writer.AppendLineFormat("# {0}", skip(desc,i).Content);

                    TableSigs.Add(sig);
                }
                return data;
            }

            void EmitConsolidated(Index<RuleTableRow> src)
            {
                var count = src.Count;
                Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];

                var kind = src.First.TableKind;
                var name = src.First.TableName;
                var sig = XedRules.sig(kind,name);
                var length = 0u;
                var offset = 0u;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var row = ref src[i];
                    if(i == count - 1)
                        RuleTableRow.RenderWidths(sig, slice(src.View,offset,length), widths);
                    else if(row.TableName != name)
                    {
                        if(row.TableName != name)
                        {
                            RuleTableRow.RenderWidths(sig, slice(src.View,offset,length), widths);
                            kind = row.TableKind;
                            name = row.TableName;
                            sig = XedRules.sig(kind,name);
                            length = 0;
                            offset = i;
                        }
                        length++;
                    }
                }

                TableEmit(src.View, widths, XedPaths.TableDef(kind));
            }

            void EmitDescriptions(RuleTableKind kind, RuleTableDefs src)
            {
                var path = XedPaths.TableInfo(kind);
                var emitting = EmittingFile(path);
                using var dst = path.AsciWriter();
                var sigs = src.Keys.ToArray().Sort();
                var count = sigs.Length;
                for(var i=0; i<count; i++)
                    dst.AppendLine(XedRender.format(src[skip(sigs,i)]));
                EmittedFile(emitting, sigs.Length);
            }

            RuleTableDefs CalcEncDecTableDefs()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = RuleTableParser.tables(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
                foreach(var t in enc)
                    dst.TryAdd(t.Sig, t);
                return dst;
            }

            RuleTableDefs CalcEncTableDefs()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = RuleTableParser.tables(XedPaths.DocSource(XedDocKind.EncRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            RuleTableDefs CalcDecTableDefs()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = RuleTableParser.tables(XedPaths.DocSource(XedDocKind.DecRuleTable));
                foreach(var t in enc)
                    dst.TryAdd(t.Sig, t);
                return dst;
            }

            Index<RuleSchema> CalcRuleSchemas(ReadOnlySpan<RuleTable> tables, ConcurrentBag<RuleSchema> dst)
            {
                iter(tables, t => {
                    var s = schema(t);
                    if(s.IsNonEmpty)
                        dst.Add(s);
                    }, PllWf);
                return dst.Array().Sort();
            }
        }
    }
}