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

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Criterion.Field;
            }

            public RuleCellSpec Spec
            {
                [MethodImpl(Inline)]
                get => new RuleCellSpec(Criterion.Premise, TableKind, Criterion.DataKind, Criterion.DataKind == CellDataKind.Nonterminal, Criterion.Field);
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

            public static RuleTableCell Empty => default;
        }
    }
}