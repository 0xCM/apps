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
        public readonly struct RuleCellType
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;



        }
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleCriterion
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            readonly ByteBlock16 Storage;

            public readonly RuleCellKind Kind;

            [MethodImpl(Inline)]
            internal RuleCriterion(FieldKind fk, RuleOperator op, Nonterminal nt)
            {
                Field = fk;
                Operator = op;
                Storage = core.bytes(expr(fk, op, new (fk,nt)));
                Kind = RuleCellKind.NontermExpr;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(FieldExpr data)
            {
                Field = data.Field;
                Operator = data.Operator;
                Storage = core.bytes(data);
                Kind = data.IsEq ? RuleCellKind.FieldEq : data.IsNeq ? RuleCellKind.FieldNeq : RuleCellKind.None;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(Nonterminal nt)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = (uint)nt;
                Kind = RuleCellKind.Nonterminal;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(BfSeg data)
            {
                Field = data.Field;
                Operator = OperatorKind.None;
                Storage = core.bytes(data);
                Kind = RuleCellKind.BfSeg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(BfSpec spec)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = (byte)spec.Kind;
                Kind = RuleCellKind.BfSpec;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(RuleKeyword keword)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = core.bytes(keword);
                Kind = RuleCellKind.Keyword;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(RuleOperator op)
            {
                Field = FieldKind.INVALID;
                Operator = op;
                Storage = (byte)op;
                Kind = RuleCellKind.Operator;
            }

            public readonly ulong Data
            {
                [MethodImpl(Inline)]
                get => Storage.A;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => Kind == RuleCellKind.Nonterminal;
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
            public RuleKeyword ToKeyword()
                => core.@as<RuleKeyword>(Storage.Bytes);

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