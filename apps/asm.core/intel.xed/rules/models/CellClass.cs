//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        [DataWidth(4,8)]
        public readonly record struct CellClass : IComparable<CellClass>
        {
            public readonly RuleCellKind Kind;

            [MethodImpl(Inline)]
            public CellClass(RuleCellKind kind)
            {
                Kind = kind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public bool IsSegField
            {
                [MethodImpl(Inline)]
                get => Kind == CK.SegField;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Keyword;
            }

            public bool IsBinLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.BitLiteral;
            }

            public bool IsHexLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.HexLiteral;
            }

            public bool IsIntLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.IntLiteral;
            }

            public bool IsNumericLit
            {
                [MethodImpl(Inline)]
                get => IsBinLit || IsHexLit || IsIntLit;
            }

            public bool IsString
            {
                [MethodImpl(Inline)]
                get => Kind == CK.SegVar;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Operator;
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Kind == CK.NontermCall;
            }

            public bool IsNontermExpr
            {
                [MethodImpl(Inline)]
                get => Kind == CK.NontermExpr;
            }

            public bool IsExpr
            {
                [MethodImpl(Inline)]
                get => Kind == CK.NontermExpr || Kind == CK.EqExpr || Kind == CK.NeqExpr;
            }

            [MethodImpl(Inline)]
            public int CompareTo(CellClass src)
                => ((byte)Kind).CompareTo((byte)src.Kind);

            public string Format()
                => Kind.ToString();

            public override int GetHashCode()
                => (int)Kind;

            // public bool Equals(CellClass src)
            //     => Kind == src.Kind;

            // public override bool Equals(object src)
            //     => src is CellClass x && Equals(x);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CellClass(RuleCellKind src)
                => new CellClass(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCellKind(CellClass src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(CellClass src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator CellClass(byte src)
                => new CellClass((RuleCellKind)src);

            // [MethodImpl(Inline)]
            // public static bool operator ==(CellClass a, CellClass b)
            //     => a.Equals(b);

            // [MethodImpl(Inline)]
            // public static bool operator !=(CellClass a, CellClass b)
            //     => !a.Equals(b);

            public static CellClass Empty => default;
        }
   }
}