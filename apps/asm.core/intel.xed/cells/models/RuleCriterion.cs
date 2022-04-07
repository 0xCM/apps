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

            public readonly CellRole Role;

            [MethodImpl(Inline)]
            internal RuleCriterion(uint8b src, CellRole role)
            {
                Field = 0;
                Operator = RuleOperator.None;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(Hex8 src, CellRole role)
            {
                Field = 0;
                Operator = RuleOperator.None;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(NontermExpr src, CellRole role)
            {
                Field = src.Field;
                Operator = src.Op;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(DispSeg src, CellRole role)
            {
                Field = src.Field;
                Operator = RuleOperator.None;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(DispSpec src, CellRole role)
            {
                Field = 0;
                Operator = RuleOperator.None;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(ImmSeg src, CellRole role)
            {
                Field = src.Field;
                Operator = RuleOperator.None;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(ImmSpec src, CellRole role)
            {
                Field = 0;
                Operator = RuleOperator.None;
                Storage = (uint)src;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(CellExpr data)
            {
                Field = data.Field;
                Operator = data.Operator;
                Storage = core.bytes(data);
                Role = data.Role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(Nonterminal nt, CellRole role)
            {
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = (uint)nt;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(BfSeg data, CellRole role)
            {
                Field = data.Field;
                Operator = RuleOperator.None;
                Storage = core.bytes(data);
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(BfSpec spec, CellRole role)
            {
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = (byte)spec.Kind;
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(RuleKeyword keyword, CellRole role)
            {
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = core.bytes(keyword);
                Role = role;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(asci16 src)
            {
                Field = FieldKind.INVALID;
                Operator = RuleOperator.None;
                Storage = core.@bytes(src);
                Role = CellRole.AsciLiteral;
            }

            [MethodImpl(Inline)]
            internal RuleCriterion(RuleOperator op)
            {
                Field = FieldKind.INVALID;
                Operator = op;
                Storage = (byte)op;
                Role = CellRole.Operator;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Role == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public bool IsNonTermCall
            {
                [MethodImpl(Inline)]
                get => Role == CellRole.NontermCall;
            }

            public bool IsNonTermExpr
            {
                [MethodImpl(Inline)]
                get => Role == CellRole.NontermExpr;
            }

            [MethodImpl(Inline)]
            public CellExpr ToFieldExpr()
                => core.@as<CellExpr>(Storage.Bytes);

            [MethodImpl(Inline)]
            public asci16 ToAsciLiteral()
                => core.@as<asci16>(Storage.Bytes);

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