//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using N = XedRules.RuleOpName;
    using DK = XedRules.FieldDataKind;

    using Asm;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(CriterionKind kind, FieldKind field, RuleOperator op, string value)
            => new RuleCriterion(kind, field,op,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion<T> criterion<T>(FieldKind kind, RuleOperator op, T value)
            where T : unmanaged
                => new RuleCriterion<T>(kind,op,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static CriterionSpec convert<T>(in RuleCriterion<T> src, FieldDataType type)
            where T : unmanaged
                => new CriterionSpec(src.Kind, src.Operator, type, core.bytes(src.Value));

        internal static string format(in CriterionSpec src)
        {
            ref readonly var dk = ref src.DataType.Kind;
            ref readonly var width = ref src.DataType.Width;
            var data = src.Data;
            var value = EmptyString;
            switch(dk)
            {
                case DK.Bit:
                case DK.Imm:
                {
                    bit x = first(data);
                    value = x.Format();
                }
                break;
                case DK.Bits:
                {
                    switch(width)
                    {
                        case 1:
                        {
                            bit x = first(data);
                            value = x.Format();
                        }
                        break;
                        case 2:
                        {
                            uint2 x = first(data);
                            value = x.Format();
                        }
                        break;
                        case 3:
                        {
                            uint3 x = first(data);
                            value = x.Format();
                        }
                        break;
                        case 4:
                        {
                            uint4 x = first(data);
                            value = x.Format();
                        }
                        break;
                    }
                }
                break;
                case DK.Byte:
                {
                    byte x = first(data);
                    value = x.ToString();
                }
                break;
                case DK.Hex8:
                {
                    Hex8 x = first(data);
                    value = x.Format();
                }
                break;
                case DK.Disp:
                {
                    Disp64 x = @as<long>(data);
                    value = x.Format();
                }
                break;
                case DK.Broadcast:
                {
                    var x = @as<BCastKind>(data);
                    value = BCastKinds[x].Expr.Format();
                }
                break;
                case DK.Chip:
                {
                    var x = @as<ChipCode>(data);
                    value = ChipCodes[x].Expr.Format();
                }
                break;
                case DK.Reg:
                {
                    var x = @as<XedRegId>(data);
                    value = XedRegs[x].Expr.Format();
                }
                break;
                case DK.InstClass:
                {
                    var x = @as<IClass>(data);
                    value = InstClasses[x].Expr.Format();
                }
                break;
                case DK.Mem:
                {
                    var x = @as<text31>(data);
                    value = x.Format();
                }
                break;
                case DK.MemWidth:
                {
                    var x = @as<ushort>(data);
                    value = x.ToString();
                }
                break;
            }

            var dst = FieldKinds[src.Kind].Expr.Format();
            if(src.Operator != 0)
                dst += RuleOps[src.Operator].Expr.Format();
            dst += value;
            return dst;
        }
    }
}