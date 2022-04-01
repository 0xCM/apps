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
            internal RuleCriterion(bool premise, FieldKind fk, RuleOperator op, Nonterminal nt)
            {
                Premise = premise;
                Field = fk;
                Operator = op;
                Storage = core.bytes(XedFields.expr(fk, op, new (fk,nt)));
                DataKind = CellDataKind.NontermExpr;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldExpr data)
            {
                Premise = premise;
                Field = data.Field;
                Operator = data.Operator;
                Storage = core.bytes(data);
                DataKind = CellDataKind.FieldExpr;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, Nonterminal nt)
            {
                Premise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = (uint)nt;
                DataKind = CellDataKind.Nonterminal;
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
                Storage = core.bytes(spec);
                DataKind = CellDataKind.BfSpec;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldLiteral literal)
            {
                Premise = premise;
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = core.bytes(literal);
                DataKind = CellDataKind.FieldLiteral;
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

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => DataKind == CellDataKind.Nonterminal;
            }

            [MethodImpl(Inline)]
            public FieldExpr ToFieldExpr()
                => core.@as<FieldExpr>(Storage.Bytes);

            [MethodImpl(Inline)]
            public FieldValue ToFieldValue()
                => new FieldValue(Field, Data);

            [MethodImpl(Inline)]
            public BitfieldSeg ToBfSeg()
                => core.@as<BitfieldSeg>(Storage.Bytes);

            [MethodImpl(Inline)]
            public BitfieldSpec ToBfSpec()
                => new BitfieldSpec(Storage.Bytes);

            [MethodImpl(Inline)]
            public FieldLiteral ToFieldLiteral()
                => core.@as<FieldLiteral>(Storage.Bytes);

            [MethodImpl(Inline)]
            public Nonterminal ToNonTerminal()
                => core.@as<Nonterminal>(Storage.Bytes);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}