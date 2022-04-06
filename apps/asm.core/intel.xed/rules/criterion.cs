//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        public static FieldValue value(in RuleCriterion src)
        {
            var fmt = EmptyString;
            var value = FieldValue.Empty;
            switch(src.Kind)
            {
                case CK.None:
                    break;
                case CK.Branch:
                case CK.Null:
                case CK.Error:
                case CK.Wildcard:
                case CK.Default:
                    value = new (src.ToKeyword());
                break;
                case CK.BinaryLiteral:
                    value = new(src.Field, src.ToBinaryLiteral());
                break;
                case CK.IntLiteral:
                    value = new(src.Field, src.ToIntLiteral(), src.Kind);
                break;
                case CK.HexLiteral:
                    value = new(src.Field, src.ToHexLiteral());
                break;
                case CK.Operator:
                    value = new(src.ToOperator());
                break;
                case CK.BfSeg:
                    value = new (src.ToBfSeg());
                break;
                case CK.BfSpec:
                    value = new (src.ToBfSpec());
                break;
                case CK.DispSpec:
                    value = new(src.ToDispSpec());
                break;
                case CK.DispSeg:
                    value = new(src.Field,src.ToDispSeg());
                break;
                case CK.ImmSpec:
                    value = new(src.ToImmSpec());
                break;
                case CK.ImmSeg:
                    value = new(src.Field,src.ToImmSeg());
                break;
                case CK.NontermCall:
                    value = new(src.Field, src.ToNontermCall());
                break;
                case CK.BfSegExpr:
                    value = new(src.ToBfSeg());
                break;
                case CK.NontermExpr:
                    value = new(src.Field, src.ToNontermCall());
                break;
                case CK.EqExpr:
                    value = src.ToFieldExpr().Value;
                break;
                case CK.NeqExpr:
                    value = src.ToFieldExpr().Value;
                break;
                default:
                    Errors.Throw(string.Format("Missing case: {0}", src.Kind));
                break;

            }
            return value;
        }

        [Op]
        public static RuleCriterion criterion(in RuleCellSpec src)
        {
            var dst = RuleCriterion.Empty;
            if(!RuleParser.parse(src.Data, out dst))
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), src.Data));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(in FieldExpr src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(uint8b src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(Hex8 src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(DispSeg src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(ImmSeg src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(DispSpec src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(ImmSpec src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(RuleKeyword kw)
            => new RuleCriterion(kw);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(Nonterminal nt)
            => new RuleCriterion(nt);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(FieldKind fk, RuleOperator op, Nonterminal nt)
        {
            if(op.IsEmpty)
                return new RuleCriterion(nt);
            else
                return new RuleCriterion(new NontermExpr(fk, op, nt));
        }

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(BfSeg seg)
            => new RuleCriterion(seg);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(BfSpec src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(RuleOperator op)
            => new RuleCriterion(op);
    }
}