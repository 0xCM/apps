//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
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
        public static RuleCriterion criterion(asci16 src)
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
        public static RuleCriterion criterion(RuleKeyword kw, CellRole role = CellRole.Keyword)
            => new RuleCriterion(kw, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(Nonterminal nt, CellRole role = CellRole.NontermCall)
            => new RuleCriterion(nt, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(BfSeg seg, CellRole role = CellRole.Seg)
            => new RuleCriterion(seg, role);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(RuleOperator op)
            => new RuleCriterion(op);
    }
}