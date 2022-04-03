//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleTableCell
        {
            public readonly byte Index;

            public readonly bool IsPremise;

            public readonly RuleTableKind TableKind;

            public readonly RuleCriterion Criterion;

            [MethodImpl(Inline)]
            public RuleTableCell(bool premise, byte index,  RuleTableKind kind, RuleCriterion c)
            {
                Index = index;
                IsPremise = premise;
                TableKind = kind;
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

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => Criterion.IsNonTerminal;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleTableCell Empty => default;
        }
    }
}