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
            XedPaths XedPaths => Service(Wf.XedPaths);

            bool PllWf = true;

            ConcurrentSet<RuleSig> TableSigs {get;} = new();

            public void EmitTables(bool pll)
            {
                PllWf = pll;
                XedPaths.RuleTargets().Clear();
                TableSigs.Clear();
                exec(PllWf,
                    EmitDecTables,
                    EmitEncTables,
                    EmitEncDecTables,
                    EmitRuleSeq
                    );
                EmitRuleSigs();
            }

            void EmitRuleSigs()
                => TableEmit(CalcSigRows().View, RuleSigRow.RenderWidths, XedPaths.DocTarget(XedDocKind.RuleSigs));

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

            void EmitEncTables()
            {
                var buffer = bag<RuleTableRow>();
                void Collect(Index<RuleTableRow> src)
                {
                    for(var i=0; i<src.Count; i++)
                        buffer.Add(src[i]);
                }

                iter(CalcTableDefs(RuleTableKind.Enc).Values, t => Collect(EmitTableDef(t)), PllWf);
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

                iter(CalcTableDefs(RuleTableKind.Dec).Values, t => Collect(EmitTableDef(t)), PllWf);
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

                iter(CalcTableDefs(RuleTableKind.EncDec).Values, t => Collect(EmitTableDef(t)), PllWf);
                EmitConsolidated(buffer.Array().Sort());
            }

            public Index<RuleSeq> CalcRuleSeq()
                => new RuleSeqParser().Parse(XedPaths.DocSource(XedDocKind.RuleSeq));

            public void EmitRuleSeq()
            {
                var src = CalcRuleSeq();
                var dst = text.buffer();
                iter(src, x => dst.AppendLine(x.Format()));
                FileEmit(dst.Emit(), src.Count, XedPaths.DocTarget(XedDocKind.RuleSeq), TextEncodingKind.Asci);
            }

            Index<RuleTableRow> EmitTableDef(in RuleTable src)
            {
                var data = XedRules.rows(src).Data;
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
        }
    }
}