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
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            readonly ByteBlock16 Storage;

            public readonly RuleCellKind Kind;

            [MethodImpl(Inline)]
            internal RuleCriterion(uint8b src)
            {
                Field = 0;
                Operator = RuleOperator.Empty;
                Storage = (uint)src;
                Kind = RuleCellKind.BinaryLiteral;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(Hex8 src)
            {
                Field = 0;
                Operator = RuleOperator.Empty;
                Storage = (uint)src;
                Kind = RuleCellKind.HexLiteral;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(NontermExpr src)
            {
                Field = src.Field;
                Operator = src.Op;
                Storage = (uint)src;
                Kind = RuleCellKind.NontermExpr;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(DispSeg src)
            {
                Field = src.Field;
                Operator = RuleOperator.Empty;
                Storage = (uint)src;
                Kind = RuleCellKind.DispSeg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(DispSpec src)
            {
                Field = 0;
                Operator = RuleOperator.Empty;
                Storage = (uint)src;
                Kind = RuleCellKind.DispSpec;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(ImmSeg src)
            {
                Field = src.Field;
                Operator = RuleOperator.Empty;
                Storage = (uint)src;
                Kind = RuleCellKind.ImmSeg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(ImmSpec src)
            {
                Field = 0;
                Operator = RuleOperator.Empty;
                Storage = (uint)src;
                Kind = RuleCellKind.ImmSeg;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(FieldExpr data)
            {
                Field = data.Field;
                Operator = data.Operator;
                Storage = core.bytes(data);
                Kind = data.IsEq ? RuleCellKind.EqExpr : data.IsNeq ? RuleCellKind.NeqExpr : RuleCellKind.None;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(Nonterminal nt)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = (uint)nt;
                Kind = RuleCellKind.NontermCall;
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
            internal RuleCriterion(RuleKeyword keyword)
            {
                Field = FieldKind.INVALID;
                Operator = OperatorKind.None;
                Storage = core.bytes(keyword);
                Kind = keyword.CellKind;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(RuleOperator op)
            {
                Field = FieldKind.INVALID;
                Operator = op;
                Storage = (byte)op;
                Kind = RuleCellKind.Operator;
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

            public bool IsNonTermCall
            {
                [MethodImpl(Inline)]
                get => Kind == RuleCellKind.NontermCall;
            }

            public bool IsNonTermExpr
            {
                [MethodImpl(Inline)]
                get => Kind == RuleCellKind.NontermExpr;
            }

            [MethodImpl(Inline)]
            public FieldExpr ToFieldExpr()
                => core.@as<FieldExpr>(Storage.Bytes);

            [MethodImpl(Inline)]
            public BfSeg ToBfSeg()
                => core.@as<BfSeg>(Storage.Bytes);

            [MethodImpl(Inline)]
            public BfSpec ToBfSpec()
                => (BfSpec)Storage[0];

            [MethodImpl(Inline)]
            public ImmSeg ToImmSeg()
                => (ImmSeg)core.@as<ushort>(Storage[0]);

            [MethodImpl(Inline)]
            public ImmSpec ToImmSpec()
                => (ImmSpec)Storage[0];

            [MethodImpl(Inline)]
            public DispSpec ToDispSpec()
                => (DispSpec)Storage[0];

            [MethodImpl(Inline)]
            public DispSeg ToDispSeg()
                => (DispSeg)Storage[0];

            [MethodImpl(Inline)]
            public RuleKeyword ToKeyword()
                => core.@as<RuleKeyword>(Storage.Bytes);

            [MethodImpl(Inline)]
            public Nonterminal ToNontermCall()
                => core.@as<Nonterminal>(Storage.Bytes);

            [MethodImpl(Inline)]
            public NontermExpr ToNontermExpr()
                => (NontermExpr)(core.@as<uint>(Storage.Bytes));

            [MethodImpl(Inline)]
            public RuleOperator ToOperator()
                => Operator;

            [MethodImpl(Inline)]
            public byte ToIntLiteral()
                => Storage[0];

            [MethodImpl(Inline)]
            public uint8b ToBinaryLiteral()
                => Storage[0];

            [MethodImpl(Inline)]
            public Hex8 ToHexLiteral()
                => Storage[0];

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}