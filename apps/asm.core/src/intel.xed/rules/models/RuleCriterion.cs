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

            readonly DataKind Kind;

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, ulong data)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                Data = data;
                Kind = 0;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, RuleCall call)
            {
                Require.invariant(call.IsNonEmpty);
                IsPremise = premise;
                Field = call.Field;
                Operator = call.Operator;
                Data = (ulong)call.Target;
                Kind = DataKind.Call;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, BitfieldSeg data)
            {
                IsPremise = premise;
                Field = data.Field;
                Operator = RuleOperator.Seg;
                Data = (ulong)data.Pattern;
                Kind = data.IsLiteral ? DataKind.SegLiteral : DataKind.Seg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, asci8 data)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                Data = (ulong)data;
                Kind = DataKind.Literal;
            }

            enum DataKind : byte
            {
                None,

                Literal,

                Call,

                Seg,

                SegLiteral,
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Operator == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public bool IsCall
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.Call;
            }

            public bool IsBitfieldSeg
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.Seg || Kind == DataKind.SegLiteral;
            }

            public bool IsError
            {
                [MethodImpl(Inline)]
                get => Field == FieldKind.ERROR;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Kind == DataKind.Literal;
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

            public bool IsConsequent
            {
                [MethodImpl(Inline)]
                get => !IsPremise;
            }

            [MethodImpl(Inline)]
            public RuleCall AsCall()
                => new RuleCall(Field, Operator, (NameResolver)Data);

            [MethodImpl(Inline)]
            public FieldAssign AsAssignment()
                => new FieldAssign(XedFields.value(Field, Data));

            [MethodImpl(Inline)]
            public FieldCmp AsCmp()
                => cmp(Field, Operator, XedFields.value(Field,Data));

            [MethodImpl(Inline)]
            public FieldValue AsValue()
                => new FieldValue(Field, Data);

            [MethodImpl(Inline)]
            public BitfieldSeg AsFieldSeg()
                => new BitfieldSeg(Field, (asci8)Data, Kind == DataKind.SegLiteral);

            [MethodImpl(Inline)]
            public asci8 AsLiteral()
                => (asci8)Data;

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}