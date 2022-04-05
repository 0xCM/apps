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
            public readonly Index<RuleCellSpec> Premise;

            public readonly Index<RuleCellSpec> Consequent;

            [MethodImpl(Inline)]
            public StatementSpec(RuleCellSpec[] p, RuleCellSpec[] c)
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

            public static StatementSpec Empty => new StatementSpec(sys.empty<RuleCellSpec>(), sys.empty<RuleCellSpec>());
        }
    }
}