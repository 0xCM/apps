//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct StatementSpec
        {
            public readonly Index<RuleCell> Premise;

            public readonly Index<RuleCell> Consequent;

            [MethodImpl(Inline)]
            public StatementSpec(RuleCell[] p, RuleCell[] c)
            {
                Premise = p;
                Consequent = c;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Premise.Count == 0 && Consequent.Count == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static StatementSpec Empty => new StatementSpec(sys.empty<RuleCell>(), sys.empty<RuleCell>());
        }
    }
}