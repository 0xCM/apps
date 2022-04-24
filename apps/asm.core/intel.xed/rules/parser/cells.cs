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
        partial struct CellParser
        {
            public static KeyedCells cells(RuleTables rules)
            {
                var lix = z16;
                var emitter = text.emitter();
                emitter.AppendLine(CellRender.SemanticHeader);
                ref readonly var src = ref rules.Specs();
                var sigs = src.Keys;
                var dst = dict<RuleSig,Index<KeyedCell>>();
                for(var i=z16; i<sigs.Length; i++)
                {
                    ref readonly var sig = ref skip(sigs,i);
                    var kcells = list<KeyedCell>();
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
                            var key = new CellKey(lix, tid, rix, k, logic, info.Class, sig.TableKind, sig.TableName, info.Field);
                            var result = false;
                            var field = InstField.Empty;
                            switch(info.Class.Kind)
                            {
                                case CK.BitLiteral:
                                {
                                    result = XedParsers.parse(data, out uint5 value);
                                    field = value;
                                }
                                break;

                                case CK.IntLiteral:
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
                                    result = XedParsers.parse(data, out RuleName value);
                                    field = value;
                                }
                                break;

                                case CK.Operator:
                                {
                                    if(info.Operator.IsNonEmpty)
                                        field = info.Operator;
                                    else
                                    {
                                        result = ruleop(data, out RuleOperator value);
                                        field = value;
                                    }
                                }
                                break;

                                case CK.InstSeg:
                                {
                                    result = parse(data, out InstSeg value);
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
                                    Errors.Throw(AppMsg.UnhandledCase.Format(info.Class.Kind));
                                break;
                            }

                            var kcell = KeyedCell.Empty;
                            if(result)
                                kcell = new (lix++, key,field);
                            else if(info.Field == 0 && info.Class == RuleCellKind.Operator)
                                kcell = new (lix++, key, new InstField(OperatorKind.Impl));
                            else
                                Errors.Throw(info.Field.ToString() + ":="  + key.FormatSemantic() + $":{info.Class}" + "='" + data + "'");

                            emitter.AppendLineFormat(CellRender.SemanticRenderPattern, kcell.LinearIndex, kcell.LinearIndex, kcell.Key.FormatSemantic(), kcell.Format());
                            kcells.Add(kcell);
                        }
                    }

                    dst.Add(sig, kcells.ToIndex());
                }

                return KeyedCells.create(dst, emitter.Emit());
            }
        }
    }
}