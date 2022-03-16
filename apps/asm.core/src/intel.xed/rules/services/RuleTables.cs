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
        public class RuleTables : AppService<RuleTables>
        {
            XedPaths XedPaths => Service(Wf.XedPaths);

            AppDb AppDb => Service(Wf.AppDb);

            bool PllWf {get;} = true;

            ConcurrentSet<RuleSig> TableSigs {get;} = new();

            ConcurrentDictionary<RuleSig,RuleSchema> Schemas {get;} = new();

            public void EmitTables()
            {
                XedPaths.RuleTables().Clear();
                TableSigs.Clear();
                Schemas.Clear();
                exec(PllWf,
                    EmitDecTables,
                    EmitEncTables,
                    EmitEncDecTables,
                    EmitRuleSchemas
                    );
                EmitSigs();
            }

            public RuleTableSet CalcTables(RuleTableKind kind)
                => kind switch{
                    RuleTableKind.Enc => CalcEncTables(),
                    RuleTableKind.Dec => CalcDecTables(),
                    RuleTableKind.EncDec => CalcEncDecTables(),
                    RuleTableKind.Joined => CalcTableJoins(),
                    _ => RuleTableSet.Empty
                };

            void EmitEncTables()
            {
                var buffer = bag<RuleTableRow>();
                void Collect(Index<RuleTableRow> src)
                {
                    for(var i=0; i<src.Count; i++)
                        buffer.Add(src[i]);
                }

                var src = CalcTables(RuleTableKind.Enc);
                iter(src.Values, t => Collect(EmitTable("rules.tables/enc", t)), PllWf);
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

                var src = CalcTables(RuleTableKind.Dec);
                iter(src.Values, t => Collect(EmitTable("rules.tables/dec", t)), PllWf);
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

                var src = CalcTables(RuleTableKind.EncDec);
                iter(src.Values, t => Collect(EmitTable("rules.tables/encdec", t)), PllWf);
                EmitDescriptions(RuleTableKind.EncDec, src);
                EmitConsolidated(buffer.Array().Sort());
            }

            void EmitSigs()
            {
                const string RenderPattern = "{0,-12} | {1,-16} | {2}";
                var sigs = TableSigs.Members.Array().Sort();
                var path = XedPaths.TableSigs();
                using var writer = path.AsciWriter();
                writer.AppendLineFormat(RenderPattern, "Kind", "Class", "Name");
                iter(sigs, sig => writer.AppendLineFormat(RenderPattern, sig.TableKind, sig.Class, sig.Name));
            }

            public Index<RuleTableRow> CalcTableRows(RuleTableKind kind)
            {
                var src = CalcTables(kind);
                var buffer = bag<RuleTableRow>();
                iter(src.Values, t => iter(rows(t).Data, row => buffer.Add(row), PllWf), PllWf);
                return buffer.Array().Sort();
            }

            Index<RuleTableRow> EmitTable(string scope, in RuleTable src)
            {
                var data = rows(src).Data;
                var specs = hashset<RuleCellSpec>();

                ref readonly var sig = ref src.Sig;
                Span<byte> widths = stackalloc byte[RuleTableRow.FieldCount];
                RuleTableRow.RenderWidths(sig, data, widths);
                var path = AppDb.XedTable<RuleTableRow>(scope, sig.Name);
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

                TableEmit(src.View, widths, AppDb.XedTable<RuleTableRow>("rules.tables", kind.ToString().ToLower()));
            }

            void EmitDescriptions(RuleTableKind kind, RuleTableSet src)
            {
                var path = XedPaths.TableInfo(kind);
                var emitting = EmittingFile(path);
                using var dst = path.AsciWriter();
                var sigs = src.Keys.ToArray().Sort();
                var count = sigs.Length;
                for(var i=0; i<count; i++)
                    dst.AppendLine(src[skip(sigs,i)].Format());
                EmittedFile(emitting, sigs.Length);
            }

            RuleTableSet CalcTableJoins()
            {
                void OnError(string src)
                    => Write(src, FlairKind.Error);

                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();

                var encdec = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));

                foreach(var t in encdec)
                    dst.Add(t.Sig, t);

                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
                foreach(var t in enc)
                    dst.TryAdd(t.Sig, t);

                var dec = parser.Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));
                foreach(var t in dec)
                    dst.TryAdd(t.Sig, t);

                return dst.Values.Array().Sort();
            }

            RuleTableSet CalcEncDecTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            RuleTableSet CalcEncTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            RuleTableSet CalcDecTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));
                foreach(var t in enc)
                    dst.TryAdd(t.Sig, t);
                return dst;
            }

            void EmitRuleSchemas()
            {
                var schemas = CalcRuleSchemas();
                var count = 0u;
                iter(schemas, s => count += s.Cols.Count);
                var buffer = alloc<RuleSchemaRecord>(count);
                var j = 0u;
                foreach(var s in schemas)
                {
                    var i=z8;
                    foreach(var c in s.Cols)
                    {
                        ref var dst = ref seek(buffer,j);
                        dst.Seq = j;
                        dst.ColKind = c.Premise ? 'P' : 'C';
                        dst.TableName = s.Sig.Name;
                        dst.Index = i++;
                        dst.TableField = c.Field;
                        dst.TableKind = s.Sig.TableKind;
                        j++;
                    }
                }

                TableEmit(@readonly(buffer), RuleSchemaRecord.RenderWidths, AppDb.XedTable<RuleSchemaRecord>("rules.tables"));
            }

            Index<RuleSchema> CalcRuleSchemas()
            {
                var dst = bag<RuleSchema>();
                exec(true,
                    () => CalcRuleSchemas(CalcTables(RuleTableKind.Enc).Values,dst),
                    () => CalcRuleSchemas(CalcTables(RuleTableKind.Dec).Values,dst),
                    () => CalcRuleSchemas(CalcTables(RuleTableKind.EncDec).Values,dst)
                    );
                return dst.Array().Sort();
            }

            Index<RuleSchema> CalcRuleSchemas(ReadOnlySpan<RuleTable> tables, ConcurrentBag<RuleSchema> dst)
            {
                iter(tables, t => dst.Add(schema(t)), true);
                return dst.Array().Sort();
            }

            Index<RuleSchema> CalcRuleSchemas(ReadOnlySpan<RuleTable> tables)
                => CalcRuleSchemas(tables,bag<RuleSchema>());
        }
    }
}