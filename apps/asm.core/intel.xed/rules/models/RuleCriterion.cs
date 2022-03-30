//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedFields;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleCriterion
        {
            public readonly bool Premise;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            readonly ByteBlock16 Storage;

            public readonly CellDataKind DataKind;

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldExpr data, CellDataKind kind = CellDataKind.FieldExpr)
            {
                Premise = premise;
                Field = data.Field;
                Operator = data.Operator;
                Storage = core.bytes(data);
                DataKind = kind;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, BitfieldSeg data)
            {
                Premise = premise;
                Field = data.Field;
                Operator = RuleOperator.None;
                Storage = core.bytes(data);
                DataKind = CellDataKind.BfSeg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, BitfieldSpec spec)
            {
                Premise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = spec.Pattern.View;
                DataKind = CellDataKind.BfSpec;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldLiteral literal)
            {
                Premise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = core.bytes(literal);
                DataKind = CellDataKind.Literal;
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

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Literal;
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.FieldExpr || DataKind == CellDataKind.Nonterminal;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Nonterminal;
            }

            [MethodImpl(Inline)]
            public FieldExpr AsFieldExpr()
                => core.@as<FieldExpr>(Storage.Bytes);

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
            public FieldLiteral AsLiteral()
                => core.@as<FieldLiteral>(Storage.Bytes);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}