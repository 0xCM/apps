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
        public struct RuleGridCell
        {
            public byte Index;

            public readonly bool IsPremise;

            public readonly RuleTableKind TableKind;

            public readonly RuleCriterion Criterion;

            [MethodImpl(Inline)]
            public RuleGridCell(bool premise, byte index, RuleTableKind kind, RuleCriterion c)
            {
                Index = index;
                IsPremise = premise;
                TableKind = kind;
                Criterion = c;
            }

            [MethodImpl(Inline)]
            public RuleGridCell(bool premise, byte index, RuleTableKind kind, RuleOperator op)
            {
                Index = index;
                IsPremise = premise;
                TableKind = kind;
                Criterion = criterion(op);
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
                => IsEmpty ? EmptyString : Criterion.Format();

            public override string ToString()
                => Format();

            public static RuleGridCell Empty => default;
        }
    }
}