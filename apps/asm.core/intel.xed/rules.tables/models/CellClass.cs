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
        public readonly struct CellClass
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

            public bool IsSeg
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Seg;
            }

            public bool IsSegVar
            {
                [MethodImpl(Inline)]
                get => Kind == CK.SegVar;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Keyword;
            }

            public bool IsNumber
            {
                [MethodImpl(Inline)]
                get => Kind == CK.HexLiteral || Kind == CK.IntLiteral || Kind == CK.BinaryLiteral;
            }

            public bool IsString
            {
                [MethodImpl(Inline)]
                get => Kind == CK.String;
            }

            public bool IsSegLiteral
            {
                [MethodImpl(Inline)]
                get => Kind == CK.SegLiteral;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Operator;
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Nonterm;
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

            public string Format()
            {
                var dst = Kind.ToString();

                return dst;
            }

            public override int GetHashCode()
                => (int)Kind;

            public bool Equals(CellClass src)
                => Kind == src.Kind;

            public override bool Equals(object src)
                => src is CellClass x && Equals(x);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CellClass(RuleCellKind src)
                => new CellClass(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCellKind(CellClass src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static bool operator ==(CellClass a, CellClass b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(CellClass a, CellClass b)
                => !a.Equals(b);

            public static CellClass Empty => default;
        }
   }
}