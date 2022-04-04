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
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            readonly ByteBlock16 Storage;

            public readonly CellDataKind DataKind;

            [MethodImpl(Inline)]
            internal RuleCriterion(FieldKind fk, RuleOperator op, Nonterminal nt)
            {
                Field = fk;
                Operator = op;
                Storage = core.bytes(expr(fk, op, new (fk,nt)));
                DataKind = CellDataKind.NontermExpr;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(FieldExpr data)
            {
                Field = data.Field;
                Operator = data.Operator;
                Storage = core.bytes(data);
                DataKind = data.IsEq ? CellDataKind.FieldEq : data.IsNeq ? CellDataKind.FieldNeq : CellDataKind.None;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(Nonterminal nt)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = (uint)nt;
                DataKind = CellDataKind.Nonterminal;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(BfSeg data)
            {
                Field = data.Field;
                Operator = OperatorKind.None;
                Storage = core.bytes(data);
                DataKind = CellDataKind.BfSeg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(BfSpec spec)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = (byte)spec.Kind;
                DataKind = CellDataKind.BfSpec;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(FieldLiteral literal)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = core.bytes(literal);
                DataKind = CellDataKind.FieldLiteral;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(RuleOperator op)
            {
                Field = FieldKind.INVALID;
                Operator = op;
                Storage = (byte)op;
                DataKind = CellDataKind.Operator;
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
            public BfSeg ToBfSeg()
                => core.@as<BfSeg>(Storage.Bytes);

            [MethodImpl(Inline)]
            public BfSpec ToBfSpec()
                => new BfSpec((BfSpecKind)Storage[0]);

            [MethodImpl(Inline)]
            public FieldLiteral ToFieldLiteral()
                => core.@as<FieldLiteral>(Storage.Bytes);

            [MethodImpl(Inline)]
            public Nonterminal ToNonTerminal()
                => core.@as<Nonterminal>(Storage.Bytes);

            [MethodImpl(Inline)]
            public RuleOperator ToOperator()
                => Operator;

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}