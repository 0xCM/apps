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
        public readonly struct RuleCriterion
        {
            public readonly bool IsPremise;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, ulong data)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                Data = data;
            }

            public BitfieldSeg AsFieldSeg()
                => new BitfieldSeg(Field, (text7)Data, false);

            public bool IsError
            {
                [MethodImpl(Inline)]
                get => Field == FieldKind.ERROR;
            }

            public bool IsAssignment
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Assign;
            }

            public bool IsComparison
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.CmpNeq || Operator == RuleOperator.CmpEq;
            }

            public bool IsOutReg
            {
                [MethodImpl(Inline)]
                get => Field == FieldKind.OUTREG;
            }

            public bool IsConsequent
            {
                [MethodImpl(Inline)]
                get => !IsPremise;
            }

            public bool IsNonterminal
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Call;
            }

            public bool IsFieldSeg
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Seg;
            }

            [MethodImpl(Inline)]
            public FieldValue AsValue()
                => new FieldValue(Field, Data);

            [MethodImpl(Inline)]
            public RuleCall AsCall()
                => (NameResolver)Data;

            [MethodImpl(Inline)]
            public ImmFieldSpec AsImmField()
                => core.@as<ulong,ImmFieldSpec>(Data);

            [MethodImpl(Inline)]
            public DispFieldSpec AsDispField()
                => core.@as<ulong,DispFieldSpec>(Data);

            [MethodImpl(Inline)]
            public XedRegId AsXedReg()
                => (XedRegId)Data;

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}