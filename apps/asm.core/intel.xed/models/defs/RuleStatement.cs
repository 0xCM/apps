//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleStatement
        {
            public Index<RuleCriterion> Premise;

            public Index<RuleCriterion> Consequent;

            [MethodImpl(Inline)]
            public RuleStatement(Index<RuleCriterion> premise, Index<RuleCriterion> consequent)
            {
                Premise = premise;
                Consequent = consequent;
            }

            [MethodImpl(Inline)]
            public FieldSet Fields(bool premise)
                => fields(premise,this);

            [MethodImpl(Inline)]
            public FunctionSet Nonterminals(bool premise)
                => functions(premise,this);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Premise.IsEmpty && Consequent.IsEmpty;
            }

            public bool IsVacuous
            {
                [MethodImpl(Inline)]
                get => Consequent.IsEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleStatement Empty => new RuleStatement(sys.empty<RuleCriterion>(), sys.empty<RuleCriterion>());
        }
    }
}