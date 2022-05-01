//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        partial class RuleTables
        {
            static string SemanticHeader
                => string.Format("{0,-5} | {1,-5} | {2,-48} | {3}", "Seq", "Lix", "Key", "Value");

            static string format(in RuleCell cell)
                => string.Format("{0:D5} | {1:D5} | {2,-48} | {3}", cell.Key.Index, cell.Key.Index, cell.Key.FormatSemantic(), cell.Format());

            public static CellMetrics metrics(Index<CellTable> src)
            {
                var metrics = new CellMetrics();
                metrics.TableCount = (ushort)src.Count;
                metrics.CellCount = src.Select(x => x.CellCount()).Storage.Sum();
                metrics.RowCounts = src.Select(x => (ushort)x.RowCount);
                metrics.RowCount = src.Select(x => x.RowCount).Storage.Sum();
                return metrics;
            }

            public static Index<RuleCellRecord> records(Index<CellTable> src)
            {
                var seq = z16;
                var kCells = src.Select(x => x.CellCount()).Storage.Sum();
                var dst = alloc<RuleCellRecord>(kCells);
                for(var i=0; i<src.Count; i++)
                    records(src[i], ref seq, dst);
                return dst;
            }

            static void records(in CellTable table, ref ushort seq, Span<RuleCellRecord> dst)
            {
                for(var j=z16; j<table.RowCount; j++)
                    records(table[j], ref seq, dst);
            }

            static void records(in CellRow row, ref ushort seq, Span<RuleCellRecord> dst)
            {
                for(var k=z16; k<row.CellCount; k++, seq++)
                    seek(dst,seq) = record(seq, row[k]);
            }

            static RuleCellRecord record(ushort seq, in RuleCell cell)
            {
                ref readonly var value = ref cell.Value;
                var dst = RuleCellRecord.Empty;
                dst.Seq = seq++;
                dst.Index = cell.Key.Index;
                dst.Table = cell.TableIndex;
                dst.Row = cell.RowIndex;
                dst.Col = cell.CellIndex;
                dst.Logic = cell.Logic;
                dst.Type = value.CellKind;
                dst.Kind = cell.TableKind;
                dst.Rule = cell.Rule.TableName;
                dst.Field = cell.Field;
                dst.Value = value;
                dst.Expression = RuleCell.formatter()(cell);
                dst.Op = cell.Operator();
                return dst;
            }

            public static RuleCells dataset(Dictionary<RuleSig,Index<RuleCell>> src, string desc)
            {
                var data = tables(src.ToConcurrentDictionary());
                var sigcells = core.pairings(src.Map(x => core.paired(x.Key,x.Value)));
                return new RuleCells(sigcells, data, metrics(data), records(data), desc);
            }

            public static RuleCells cells(RuleTables rules)
            {
                var lix = z16;
                var emitter = text.emitter();
                emitter.AppendLine(SemanticHeader);
                ref readonly var src = ref rules.Specs();
                var sigs = src.Keys;
                var dst = dict<RuleSig,Index<RuleCell>>();
                for(var i=z16; i<sigs.Length; i++)
                {
                    ref readonly var sig = ref skip(sigs,i);
                    var kcells = list<RuleCell>();
                    var table = src[sig];
                    ref readonly var tid = ref table.TableId;
                    ref readonly var rows = ref table.Rows;
                    for(var j=z16; j<rows.Count; j++)
                    {
                        ref readonly var row = ref rows[j];
                        ref readonly var rix = ref row.RowIndex;
                        ref readonly var cells = ref row.Cells;
                        for(var k=z8; k<cells.Count; k++)
                        {
                            ref readonly var info = ref cells[k];
                            ref readonly var data = ref info.Data;
                            ref readonly var logic = ref info.Logic;
                            var key = new CellKey(lix++, tid, rix, k, logic, info.Kind, sig.TableKind, sig.TableName, info.Field);
                            var result = false;
                            var field = InstField.Empty;
                            switch(info.Kind)
                            {
                                case CK.BitLiteral:
                                {
                                    result = XedParsers.parse(data, out uint5 value);
                                    field = value;
                                }
                                break;

                                case CK.IntVal:
                                {
                                    result = XedParsers.parse(data, out byte value);
                                    field = value;
                                }
                                break;

                                case CK.HexLiteral:
                                {
                                    result = XedParsers.parse(data, out Hex8 value);
                                    field = value;
                                }
                                break;

                                case CK.Keyword:
                                {
                                    result = XedParsers.parse(data, out RuleKeyword value);
                                    field = value;
                                }
                                break;

                                case CK.SegVar:
                                {
                                    result = XedParsers.parse(data, out SegVar value);
                                    field = value;
                                }
                                break;

                                case CK.NontermCall:
                                {
                                    result = XedParsers.parse(data, out Nonterminal value);
                                    field = value;
                                }
                                break;

                                case CK.Operator:
                                {
                                    if(info.Operator.IsNonEmpty)
                                        field = info.Operator;
                                    else
                                    {
                                        result = CellParser.ruleop(data, out RuleOperator value);
                                        field = value;
                                    }
                                }
                                break;

                                case CK.SegField:
                                {
                                    result = CellParser.segfield(data, out SegField value);
                                    field = value;
                                }
                                break;
                                case CK.InstSeg:
                                {
                                    result = CellParser.parse(data, out InstSeg value);
                                    field = value;
                                }
                                break;

                                case CK.NontermExpr:
                                case CK.EqExpr:
                                case CK.NeqExpr:
                                {
                                    result = CellParser.expr(data, out CellExpr value);
                                    field = value;
                                }
                                break;

                                default:
                                    Errors.Throw(AppMsg.UnhandledCase.Format(info.Kind));
                                break;
                            }

                            var kcell = RuleCell.Empty;
                            if(result)
                                kcell = new (key,field);
                            else if(info.Field == 0 && info.Kind == RuleCellKind.Operator)
                                kcell = new (key, new InstField(OperatorKind.Impl));
                            else
                                Errors.Throw(info.Field.ToString() + ":="  + key.FormatSemantic() + $":{info.Kind}" + "='" + data + "'");

                            emitter.AppendLineFormat(format(kcell));
                            kcells.Add(kcell);
                        }
                    }

                    dst.Add(sig, kcells.ToIndex());
                }

                return dataset(dst, emitter.Emit());
            }
        }
    }
}