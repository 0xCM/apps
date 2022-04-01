//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedFields;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, in FieldExpr src)
            => new RuleCriterion(premise, src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, FieldLiteral literal)
            => new RuleCriterion(premise, literal);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(bool premise, FieldKind fk, RuleOperator op, Nonterminal nt)
            => new RuleCriterion(premise, XedFields.expr(fk, op, new (fk,nt)), CellDataKind.Nonterminal);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion criterion(bool premise, BitfieldSeg seg)
            => new RuleCriterion(premise, seg);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion criterion(bool premise, BitfieldSpec src)
            => new RuleCriterion(premise, src);
    }
}