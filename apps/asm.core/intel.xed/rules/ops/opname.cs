//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    using K = XedRules.FieldKind;
    using N = XedModels.OpNameKind;
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        public static KeyedCellRecord record(uint seq, in KeyedCell src)
        {
            ref readonly var field = ref src.Value;
            ref readonly var key = ref src.Key;
            var dst = KeyedCellRecord.Empty;
            ref readonly var fk = ref field.FieldKind;
            ref readonly var ck = ref src.Value.DataKind;
            dst.Seq = seq;
            dst.TableId = key.TableId;
            dst.Sig = key.TableSig;
            dst.Type = ck;
            dst.Col = key.CellIndex;
            dst.Field = fk;
            dst.Logic = key.Logic;
            dst.Row = key.RowIndex;
            switch(ck)
            {
                case CK.EqExpr:
                case CK.NeqExpr:
                case CK.NontermExpr:
                {
                    dst.Op = field.ToFieldExpr().Operator;
                    dst.Value = field.ToFieldExpr().Value;
                    dst.Expression = field.ToFieldExpr().Format();
                }
                break;

                case CK.BitLiteral:
                    dst.Value = field.AsBitLit();
                    dst.Expression = XedRender.format(field.AsBitLit());
                break;

                case CK.IntLiteral:
                    dst.Value = field.AsIntLit();
                    dst.Expression = XedRender.format(field.AsIntLit());
                break;

                case CK.HexLiteral:
                    dst.Value = field.AsHexLit();
                    dst.Expression = XedRender.format(field.AsHexLit());
                break;

                case CK.SegVar:
                    dst.Value = field.AsSegVar();
                    dst.Expression = dst.Value.Format();
                break;

                case CK.Keyword:
                    dst.Value = field.ToKeyword();
                    dst.Expression = dst.Value.Format();
                break;

                case CK.NontermCall:
                    dst.Value = field.AsRuleName();
                    dst.Expression = XedRender.format(field.AsRuleName());
                break;

                case CK.Operator:
                    dst.Op = field.AsOperator();
                    dst.Value = EmptyString;
                    dst.Expression = dst.Op.Format();
                break;

                case CK.SegField:
                    dst.Value = field.AsSegField();
                    dst.Expression = dst.Value.Format();
                break;
            }

            return dst;
        }

        public static Index<KeyedCellRecord> records(KeyedCells src)
        {
            var dst = list<KeyedCellRecord>();
            var k=0u;
            var sigs = src.Keys;
            for(var i=z16; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                if(src.Find(sig, out var cells))
                {
                    for(var j=z16; j<cells.Count; j++, k++)
                        dst.Add(record(k, cells[j]));
                }
            }

            return dst.ToIndex();
        }

        [Op]
        public static OpName opname(FieldKind src)
        {
            var name = OpNameKind.None;
            switch(src)
            {
                case K.REG0:
                    name = N.REG0;
                break;
                case K.REG1:
                    name = N.REG1;
                break;
                case K.REG2:
                    name = N.REG2;
                break;
                case K.REG3:
                    name = N.REG3;
                break;
                case K.REG4:
                    name = N.REG4;
                break;
                case K.REG5:
                    name = N.REG5;
                break;
                case K.REG6:
                    name = N.REG6;
                break;
                case K.REG7:
                    name = N.REG7;
                break;
                case K.REG8:
                    name = N.REG8;
                break;
                case K.MEM0:
                    name = N.MEM0;
                break;
                case K.MEM1:
                    name = N.MEM1;
                break;
                case K.IMM0:
                    name = N.IMM0;
                break;
                case K.IMM1:
                    name = N.IMM1;
                break;
                case K.RELBR:
                    name = N.RELBR;
                break;
                case K.BASE0:
                    name = N.BASE0;
                break;
                case K.BASE1:
                    name = N.BASE1;
                break;
                case K.SEG0:
                    name = N.SEG0;
                break;
                case K.SEG1:
                    name = N.SEG1;
                break;
                case K.AGEN:
                    name = N.AGEN;
                break;
                case K.PTR:
                    name = N.PTR;
                break;
                case K.INDEX:
                    name = N.INDEX;
                break;
                case K.SCALE:
                    name = N.SCALE;
                break;
                case K.DISP:
                    name = N.DISP;
                break;
            }
            return name;
        }
    }
}