//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using R = XedRules.CellRole;

    partial class XedRules
    {
        public static CellValue value(in RuleCriterion src)
        {
            var fmt = EmptyString;
            var value = CellValue.Empty;
            switch(src.Role)
            {
                case R.None:
                    break;
                case R.Branch:
                case R.Null:
                case R.Error:
                case R.Wildcard:
                case R.Default:
                    value = new (src.ToKeyword(), src.Role);
                break;
                case R.BinaryLiteral:
                    value = new(src.Field, src.ToBinaryLiteral(), src.Role);
                break;
                case R.IntLiteral:
                    value = new(src.Field, src.ToIntLiteral(), src.Role);
                break;
                case R.HexLiteral:
                    value = new(src.Field, src.ToHexLiteral(), src.Role);
                break;
                case R.Operator:
                    value = new(src.ToOperator(), src.Role);
                break;
                case R.Seg:
                    value = new (src.ToBfSeg(), src.Role);
                break;
                case R.BfSpec:
                    value = new (src.ToBfSpec(), src.Role);
                break;
                case R.DispSpec:
                    value = new(src.ToDispSpec(), src.Role);
                break;
                case R.DispSeg:
                    value = new(src.Field,src.ToDispSeg(), src.Role);
                break;
                case R.ImmSpec:
                    value = new(src.ToImmSpec(), src.Role);
                break;
                case R.ImmSeg:
                    value = new(src.Field,src.ToImmSeg(), src.Role);
                break;
                case R.NontermCall:
                    value = new(src.Field, src.ToNontermCall(), src.Role);
                break;
                case R.BfSegExpr:
                    value = new(src.ToBfSeg(), src.Role);
                break;
                case R.NontermExpr:
                    value = new(src.Field, src.ToNontermCall(), src.Role);
                break;
                case R.EqExpr:
                    value = src.ToFieldExpr().Value;
                break;
                case R.NeqExpr:
                    value = src.ToFieldExpr().Value;
                break;
                default:
                    Errors.Throw(string.Format("Missing case: {0}", src.Role));
                break;

            }
            return value;
        }

        [Op]
        public static RuleCriterion criterion(in CellSpec src)
        {
            var dst = RuleCriterion.Empty;
            if(!CellParser.parse(src.Data, out dst))
                Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), src.Data));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(in CellExpr src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(uint8b src, CellRole role = CellRole.BinaryLiteral)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(Hex8 src, CellRole role = CellRole.HexLiteral)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(DispSeg src, CellRole role = CellRole.Seg)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(ImmSeg src, CellRole role = CellRole.Seg)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(DispSpec src, CellRole role)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(ImmSpec src, CellRole role)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(RuleKeyword kw, CellRole role = CellRole.Keyword)
            => new RuleCriterion(kw, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(Nonterminal nt, CellRole role = CellRole.NontermCall)
            => new RuleCriterion(nt, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(FieldKind fk, RuleOperator op, Nonterminal nt)
        {
            if(op.IsEmpty)
                return new RuleCriterion(nt, CellRole.NontermCall);
            else
                return new RuleCriterion(new NontermExpr(fk, op, nt), CellRole.NontermExpr);
        }

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(BfSeg seg, CellRole role = CellRole.Seg)
            => new RuleCriterion(seg, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(BfSpec src, CellRole role = CellRole.SegSpec)
            => new RuleCriterion(src, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(RuleOperator op)
            => new RuleCriterion(op);
    }
}