//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct RuleTableCell
        {
            public readonly byte Index;

            public readonly RuleTableKind TableKind;

            public readonly RuleCriterion Criterion;

            [MethodImpl(Inline)]
            public RuleTableCell(RuleTableKind tk, byte index, RuleCriterion c)
            {
                TableKind = tk;
                Index = index;
                Criterion = c;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Criterion.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Criterion.IsNonEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleTableCell Empty => default;
        }
    }
}