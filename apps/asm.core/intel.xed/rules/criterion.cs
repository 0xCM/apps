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
        public static RuleCriterion criterion(in FieldExpr src)
            => new RuleCriterion(src);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(FieldLiteral literal)
            => new RuleCriterion(literal);

        [MethodImpl(Inline), Op]
        public static RuleCriterion criterion(FieldKind fk, RuleOperator op, Nonterminal nt)
        {
            if(op==0)
                return new RuleCriterion(nt);
            else
                return new RuleCriterion(fk, op, nt);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion criterion(BfSeg seg)
            => new RuleCriterion(seg);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static RuleCriterion criterion(BfSpec src)
            => new RuleCriterion(src);
    }
}