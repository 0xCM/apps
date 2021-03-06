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
        internal class RuleBuffers
        {
            public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Target = new();
        }

        internal static RuleTables tables(RuleBuffers buffers)
        {
            ref readonly var src = ref buffers.Target;
            var enc = src[RuleTableKind.ENC];
            var dec = src[RuleTableKind.DEC];
            var dst = enc.Append(dec).Where(x => x.IsNonEmpty).Sort();
            for(var i=0u; i<dst.Count; i++)
                dst[i] = dst[i].WithId(i);
            return new RuleTables(dst, RuleSpecs.tables(dst));
        }

        public partial class RuleTables
        {
            Index<TableCriteria> _Criteria;

            TableSpecs _Specs;

            [MethodImpl(Inline)]
            internal ref readonly Index<TableCriteria> Criteria()
                => ref _Criteria;

            [MethodImpl(Inline)]
            public ref readonly TableSpecs Specs()
                => ref _Specs;

            public RuleTables()
            {
                _Criteria = sys.empty<TableCriteria>();
                _Specs = TableSpecs.Empty;
            }

            public static RuleTables Empty
                => new RuleTables();

            public RuleTables(Index<TableCriteria> criteria, TableSpecs specs)
            {
                _Criteria = criteria;
                _Specs = specs;
            }

            static bool seg(string src, out FieldSeg dst)
            {
                dst = FieldSeg.Empty;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var result = i>0 && j>i;
                if(result)
                {
                    XedParsers.parse(text.left(src,i), out FieldKind field);
                    XedParsers.segdata(src, out var data);
                    result = field != 0 && text.nonempty(data);
                    if(result)
                    {
                        var literal = XedParsers.IsBinaryLiteral(data);
                        if(literal)
                            dst = FieldSeg.literal(field, data);
                        else
                            dst = FieldSeg.symbolic(field, data);
                    }
                }
                else
                {
                    dst = FieldSeg.symbolic(src);
                    result = true;
                }

                return result;
            }

            public static CellDatasets datasets(RuleTables tables)
            {
                var lix = z16;
                var emitter = text.emitter();
                emitter.AppendLine(string.Format("{0,-5} | {1,-5} | {2,-48} | {3}", "Seq", "Lix", "Key", "Value"));
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
                            var cell = RuleCell.Empty;

                            switch(info.Kind)
                            {
                                case CK.BitLit:
                                {
                                    result = XedParsers.parse(data, out uint5 value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.IntVal:
                                {
                                    result = XedParsers.parse(data, out ushort value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.HexLit:
                                {
                                    result = XedParsers.parse(data, out Hex8 value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.Keyword:
                                {
                                    result = XedParsers.parse(data, out RuleKeyword value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.SegVar:
                                {
                                    result = XedParsers.parse(data, out SegVar value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.WidthVar:
                                {
                                    result = XedParsers.parse(data, out WidthVar wv);
                                    cell = new RuleCell(key, wv, size);
                                }
                                break;

                                case CK.NtCall:
                                {
                                    result = XedParsers.parse(data, out Nonterminal value);
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
                                        result = RuleSpecs.ruleop(data, out RuleOperator value);
                                        cell = new RuleCell(key, value, size);
                                    }
                                }
                                break;

                                case CK.FieldSeg:
                                {
                                    result = seg(data, out FieldSeg value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;
                                case CK.InstSeg:
                                {
                                    result = CellParser.parse(data, out InstFieldSeg value);
                                    cell = new RuleCell(key, value, size);
                                }
                                break;

                                case CK.NtExpr:
                                case CK.EqExpr:
                                case CK.NeqExpr:
                                {
                                    result = CellParser.expr(data, out CellExpr value);
                                    if(value.Field == 0)
                                        term.warn(AppMsg.ParseFailure.Format(nameof(FieldKind), data));
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

                return CellDatasets.create(dst, emitter.Emit());
            }

            static string format(in RuleCell cell)
                => string.Format("{0:D5} | {1:D5} | {2,-48} | {3}", cell.Key.Index, cell.Key.Index, cell.Key.Format(), cell.Format());
        }
    }
}