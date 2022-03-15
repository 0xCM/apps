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

            ConcurrentSet<string> RuleTableNames {get;} = new();

            public void EmitTables()
            {
                var scope = "rules.tables";
                AppDb.Xed(scope).Clear();
                RuleTableNames.Clear();
                exec(PllWf,
                    EmitJoinedTables,
                    EmitDecTables,
                    EmitEncTables,
                    EmitEncDecTables
                    );
                EmitTableNames(scope);
            }

            void EmitJoinedTables()
            {
                var src = CalcTables();

                EmitTableDescriptions(src);
                iter(src.Values, t => EmitRuleTable("rules.tables/joined", RuleTables.rows(t)), PllWf);
            }

            void EmitTableNames(string scope)
            {
                var path = AppDb.XedPath(scope, "rules.tables.names", FileKind.Csv);
                var emitting = EmittingFile(path);
                using var writer = path.AsciWriter();
                writer.WriteLine("TableName");
                var names = RuleTableNames.Members.Array().Sort();
                iter(names, n => writer.WriteLine(n));
                EmittedFile(emitting, names.Length);
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
                RuleTableNames.Add(src.TableSig.Name);
            }

            void EmitDecTables()
                => iter(CalcDecTables().Values, t => EmitRuleTable("rules.tables/dec", RuleTables.rows(t)), PllWf);

            void EmitEncDecTables()
                => iter(CalcEncDecTables().Values, t => EmitRuleTable("rules.tables/encdec", RuleTables.rows(t)), PllWf);

            void EmitEncTables()
                => iter(CalcEncTables().Values, t => EmitRuleTable("rules.tables/enc", RuleTables.rows(t)), PllWf);

            void EmitTableDescriptions(RuleTableLookup src)
            {
                var path = XedPaths.DocTarget(XedDocKind.RuleTable);
                var emitting = EmittingFile(path);
                using var dst = path.AsciWriter();
                var sigs = src.Keys.ToArray().Sort();
                var count = sigs.Length;
                for(var i=0; i<count; i++)
                    dst.AppendLine(src[skip(sigs,i)].Format());
                EmittedFile(emitting, sigs.Length);
            }

            public RuleTableLookup CalcTables()
            {
                void OnError(string src)
                    => Write(src, FlairKind.Error);

                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();

                var encdec = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
                foreach(var t in encdec)
                    dst.TryAdd(t.Sig, t);

                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
                foreach(var t in enc)
                    dst.TryAdd(t.Sig, t);

                var dec = parser.Parse(XedPaths.DocSource(XedDocKind.DecRuleTable));
                foreach(var t in dec)
                    dst.TryAdd(t.Sig, t);
                var tables = dst.Values.Array();
                iter(tables, t => t.TableSig = new (RuleTableKind.Joined, t.Sig.Name));

                return tables;
            }

            public RuleTableLookup CalcEncDecTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncDecRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            public RuleTableLookup CalcEncTables()
            {
                var parser = new RuleTableParser();
                var dst = dict<RuleSig,RuleTable>();
                var enc = parser.Parse(XedPaths.DocSource(XedDocKind.EncRuleTable));
                foreach(var t in enc)
                    dst.Add(t.Sig, t);
                return dst;
            }

            public RuleTableLookup CalcDecTables()
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
                for(byte i=0; i<src.Expressions.Count; i++)
                {
                    ref readonly var expr = ref src.Expressions[i];
                    var m=z8;
                    var row = RuleTableRow.Empty;
                    row.TableName = src.Name;
                    row.RowIndex = i;
                    for(var k=0; k<expr.Premise.Count; k++)
                        assign(m++, expr.Premise[k], ref row);

                    m = 6;

                    for(var k=0; k<expr.Consequent.Count; k++)
                        assign(m++, expr.Consequent[k], ref row);

                    dst.Add(row);
                }
                return new RuleTableRows(src.TableSig,  dst.ToArray());
            }

            static void assign(byte i, in RuleCriterion src, ref RuleTableRow dst)
                => dst[i] = new RuleTableCell(i,src);
        }
    }
}