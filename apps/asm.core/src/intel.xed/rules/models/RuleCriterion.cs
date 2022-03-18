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
            public readonly bool Premise;

            public readonly bool IsNonterminal;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            readonly ByteBlock16 Storage;

            public readonly CellDataKind DataKind;

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, ulong data)
            {
                Premise = premise;
                Field = field;
                Operator = op;
                Storage = data;
                DataKind = field == FieldKind.ERROR ? CellDataKind.Error : CellDataKind.FieldValue;
                IsNonterminal = false;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, Nonterminal data)
            {
                Premise = premise;
                Field = field;
                Operator = op;
                Storage = core.bytes(data);
                DataKind = CellDataKind.FieldValue;
                IsNonterminal = true;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, RuleCall call)
            {
                Require.invariant(call.IsNonEmpty);
                Premise = premise;
                Field = call.Field;
                Operator = call.Operator;
                Storage = (ulong)call.Target;
                DataKind = CellDataKind.Call;
                IsNonterminal = true;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, BitfieldSeg data)
            {
                Premise = premise;
                Field = data.Field;
                Operator = RuleOperator.None;
                Storage = core.bytes(data);
                DataKind = CellDataKind.BfSeg;
                IsNonterminal = false;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, BitfieldSpec spec)
            {
                Premise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = spec.Pattern.View;
                DataKind = CellDataKind.BfSpec;
                IsNonterminal = false;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, asci8 data, CellDataKind dk)
            {
                Premise = premise;
                Field = field;
                Operator = op;
                Storage = (ulong)data;
                DataKind = dk;
                IsNonterminal = false;
            }

            public readonly ulong Data
            {
                [MethodImpl(Inline)]
                get => Storage.A;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => DataKind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public bool IsNull
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Null;
            }

            public bool IsCall
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Call;
            }

            public bool IsBfSeg
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.BfSeg;
            }

            public bool IsBfSpec
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.BfSpec;
            }

            public bool IsError
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Error;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Literal;
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
                get => !Premise;
            }

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterminal()
                => ref core.@as<Nonterminal>(Storage.Bytes);

            [MethodImpl(Inline)]
            public RuleCall AsCall()
                => new RuleCall(Field, Operator, (NameResolver)Data);

            [MethodImpl(Inline)]
            public FieldAssign AsAssignment()
                => new FieldAssign(XedFields.value(Field, Data));

            [MethodImpl(Inline)]
            public FieldCmp AsCmp()
                => cmp(Field, Operator, XedFields.value(Field, Data));

            [MethodImpl(Inline)]
            public FieldValue AsValue()
                => new FieldValue(Field, Data);

            [MethodImpl(Inline)]
            public BitfieldSeg AsBfSeg()
                => core.@as<BitfieldSeg>(Storage.Bytes);

            [MethodImpl(Inline)]
            public BitfieldSpec AsBfSpec()
                => new BitfieldSpec(new asci16(Storage.Bytes));

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