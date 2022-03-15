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

            public void EmitTables()
            {
                XedPaths.RuleTables().Clear();
                TableSigs.Clear();
                exec(PllWf,
                    EmitDecTables,
                    EmitEncTables,
                    EmitEncDecTables
                    );
                EmitSigs();
            }

            public RuleTableLookup CalcTables(RuleTableKind kind)
                => kind switch{
                    RuleTableKind.Enc => CalcEncTables(),
                    RuleTableKind.Dec => CalcDecTables(),
                    RuleTableKind.EncDec => CalcEncDecTables(),
                    RuleTableKind.Joined => CalcTableJoins(),
                    _ => RuleTableLookup.Empty
                };

            void EmitJoinedTables()
            {
                var src = CalcTables(RuleTableKind.Joined);
                iter(src.Values, t => EmitRuleTable("rules.tables/joined", rows(t)), PllWf);
            }

            void EmitEncTables()
            {
                var src = CalcTables(RuleTableKind.Enc);
                iter(src.Values, t => EmitRuleTable("rules.tables/enc", rows(t)), PllWf);
                EmitDescriptions(RuleTableKind.Enc, src);
            }

            void EmitDecTables()
            {
                var src = CalcTables(RuleTableKind.Dec);
                iter(src.Values, t => EmitRuleTable("rules.tables/dec", rows(t)), PllWf);
                EmitDescriptions(RuleTableKind.Dec, src);
            }

            void EmitEncDecTables()
            {
                var src = CalcTables(RuleTableKind.EncDec);
                iter(src.Values, t => EmitRuleTable("rules.tables/encdec", rows(t)), PllWf);
                EmitDescriptions(RuleTableKind.EncDec, src);
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

            void EmitRuleTable(string scope, in RuleTableRows src)
            {
                const byte ColCount = RuleTableRow.ColCount;
                const byte FieldCount = RuleTableRow.FieldCount;

                var data = src.Data;
                var count = data.Count;
                Span<byte> widths = stackalloc byte[FieldCount];

                seek(widths, 0) = max((byte)(src.TableSig.Name.Length + 1), (byte)12);
                seek(widths, 1) = 12;

                byte offset = 2;

                for(var i=offset; i<FieldCount; i++)
                    seek(widths,i) = 8;

                for(var i=0; i<count; i++)
                {
                    ref readonly var row = ref data[i];
                    for(byte j=0,k=offset; j<ColCount; j++, k++)
                    {
                        var cell = row[j];
                        var width = cell.Format().Length;
                        if(width > skip(widths,k))
                            seek(widths,k) = (byte)width;
                    }
                }

                TableEmit(data.View, widths, AppDb.XedTable<RuleTableRow>(scope, src.TableSig.Name));
                TableSigs.Add(src.TableSig);
            }

            void EmitDescriptions(RuleTableKind kind, RuleTableLookup src)
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

            RuleTableLookup CalcTableJoins()
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

            RuleTableLookup CalcEncDecTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            RuleTableLookup CalcEncTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            RuleTableLookup CalcDecTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));
                foreach(var t in enc)
                    dst.TryAdd(t.Sig, t);
                return dst;
            }

            static RuleTableRows rows(in RuleTable src)
            {
                var dst = list<RuleTableRow>();
                for(byte i=0; i<src.Body.Count; i++)
                {
                    ref readonly var expr = ref src.Body[i];
                    var m=z8;
                    var row = RuleTableRow.Empty;
                    row.TableName = src.Sig.Name;
                    row.RowIndex = i;
                    for(var k=0; k<expr.Premise.Count; k++)
                        assign(m++, expr.Premise[k], ref row);

                    m = 6;

                    for(var k=0; k<expr.Consequent.Count; k++)
                        assign(m++, expr.Consequent[k], ref row);

                    dst.Add(row);
                }
                return new RuleTableRows(src.Sig,  dst.ToArray());
            }

            static void assign(byte i, in RuleCriterion src, ref RuleTableRow dst)
                => dst[i] = new RuleTableCell(i,src);
        }
    }
}