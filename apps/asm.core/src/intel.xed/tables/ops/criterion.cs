//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static XedModels;
    using static XedRules;

    using R = XedRules;

    partial class XedRuleTables
    {
        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, FieldLiteral literal)
            => new RuleCriterion(premise, literal);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, RuleCall call)
            => new RuleCriterion(premise, call);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, FieldKind fk, RuleOperator op, Nonterminal nt)
            => new RuleCriterion(premise, fk, op, nt);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion criterion(bool premise, BitfieldSeg seg)
            => new RuleCriterion(premise, seg);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion criterion(bool premise, BitfieldSpec src)
            => new RuleCriterion(premise, src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, RuleOperator op, R.FieldValue src)
            => new RuleCriterion(premise,src.Field, op, src.Data);
    }
}