//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

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

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, NontermCall data)
            {
                IsPremise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.Call;
                Data = ((ulong)data.Kind | ((ulong)Kind.Nonterm << 56));
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, GroupName data)
            {
                IsPremise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.Call;
                Data = ((ulong)data | ((ulong)Kind.Group << 56));
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, RuleOperator op, NameResolver data)
            {
                IsPremise = premise;
                Field = FieldKind.INVALID;
                Operator = op;
                Data = ((ulong)data | ((ulong)Kind.Resolver << 56));
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, asci8 data)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                Data = (ulong)data;
            }

            enum Kind : byte
            {
                None,

                Nonterm,

                Group,

                Resolver
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

            public bool IsError
            {
                [MethodImpl(Inline)]
                get => Field == FieldKind.ERROR;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Literal;
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

            public bool IsResolvable
            {
                [MethodImpl(Inline)]
                get => (Kind)(Data >> 56) == Kind.Resolver;
            }

            public bool IsResolvableCall
            {
                [MethodImpl(Inline)]
                get => (Kind)(Data >> 56) == Kind.Resolver && Operator == RuleOperator.Call;
            }

            public bool IsNontermCall
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Call && ((Kind)(Data >> 56) == Kind.Nonterm);
            }

            public bool IsGroupCall
            {
                [MethodImpl(Inline)]
                get => Operator == RuleOperator.Call && ((Kind)(Data >> 56) == Kind.Group);
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
            public NontermCall AsNontermCall()
                => new NontermCall((NonterminalKind)Data);

            [MethodImpl(Inline)]
            public GroupCall AsGroupCall()
                => new GroupCall((GroupName)Data);

            [MethodImpl(Inline)]
            public NameResolver AsResolver()
                => new NameResolver((int)Data);

            [MethodImpl(Inline)]
            public RuleCall AsResolvableCall()
                => new RuleCall(AsResolver());

            [MethodImpl(Inline)]
            public DispFieldSpec AsDispField()
                => core.@as<ulong,DispFieldSpec>(Data);

            [MethodImpl(Inline)]
            public XedRegId AsXedReg()
                => (XedRegId)Data;

            [MethodImpl(Inline)]
            public BitfieldSeg AsFieldSeg()
                => new BitfieldSeg(Field, (asci8)Data, false);

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