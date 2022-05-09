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
            public static RuleCells cells(RuleTables tables)
            {
                var lix = z16;
                var emitter = text.emitter();
                emitter.AppendLine(SemanticHeader);
                ref readonly var src = ref tables.Specs();
                var sigs = src.Keys;
                var dst = dict<RuleSig,Index<RuleCell>>();
                for(var i=z16; i<sigs.Length; i++)
                {
                    ref readonly var sig = ref skip(sigs,i);
                    var kcells = list<RuleCell>();
                    var table = src[sig];
                    ref readonly var rows = ref table.Rows;
                    for(var j=z16; j<rows.Count; j++)
                    {
                        ref readonly var row = ref rows[j];
                        ref readonly var keys = ref row.Keys;
                        for(var k=z8; k<row.CellInfo.Count; k++)
                        {
                            ref readonly var info = ref row.CellInfo[k];
                            ref readonly var data = ref info.Data;
                            ref readonly var logic = ref info.Logic;
                            ref readonly var key = ref keys[k];
                            var size = XedFields.size(key.Field, key.CellType);
                            var result = false;
                            var field = CellValue.Empty;
                            var cell = RuleCell.Empty;

                            switch(info.Kind)
                            {
                                case CK.BitLiteral:
                                {
                                    result = XedParsers.parse(data, out uint5 value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.IntVal:
                                {
                                    result = XedParsers.parse(data, out byte value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.HexLiteral:
                                {
                                    result = XedParsers.parse(data, out Hex8 value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.Keyword:
                                {
                                    result = XedParsers.parse(data, out RuleKeyword value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.SegVar:
                                {
                                    result = XedParsers.parse(data, out SegVar value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.NontermCall:
                                {
                                    result = XedParsers.parse(data, out Nonterminal value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.Operator:
                                {
                                    if(info.Operator.IsNonEmpty && info.Field == 0)
                                    {
                                        result = true;
                                        cell = new RuleCell(key, OperatorKind.Impl, size);
                                    }
                                    else
                                    {
                                        result = CellParser.ruleop(data, out RuleOperator value);
                                        field = value;
                                        cell = new RuleCell(key, value, size);
                                    }
                                }
                                break;

                                case CK.FieldSeg:
                                {
                                    result = CellParser.seg(data, out FieldSeg value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;
                                case CK.InstSeg:
                                {
                                    result = CellParser.parse(data, out InstSeg value);
                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.NontermExpr:
                                case CK.EqExpr:
                                case CK.NeqExpr:
                                {
                                    result = CellParser.expr(data, out CellExpr value);
                                    if(value.Field == 0)
                                        term.warn(AppMsg.ParseFailure.Format(nameof(FieldKind), data));

                                    field = value;
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                default:
                                    Errors.Throw(AppMsg.UnhandledCase.Format(info.Kind));
                                break;
                            }

                            if(!result)
                                Errors.Throw(info.Field.ToString() + ":="  + keys[k].Format() + $":{info.Kind}" + "='" + data + "'");

                            emitter.AppendLineFormat(format(cell));
                            kcells.Add(cell);
                        }
                    }

                    dst.Add(sig, kcells.ToIndex());
                }

                return CellDatasets.load(dst, emitter.Emit());
            }

            static string SemanticHeader
                => string.Format("{0,-5} | {1,-5} | {2,-48} | {3}", "Seq", "Lix", "Key", "Value");

            static string format(in RuleCell cell)
                => string.Format("{0:D5} | {1:D5} | {2,-48} | {3}", cell.Key.Index, cell.Key.Index, cell.Key.Format(), cell.Format());
        }
    }
}