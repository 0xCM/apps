//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = XedRules.RuleCellKind;

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

            public bool IsNumber
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Number);
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Keyword);
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Nonterm);
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Operator);
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Literal);
            }

            public bool IsValue
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Value);
            }

            public bool IsChar
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Char);
            }

            public bool IsString
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.String);
            }

            public bool IsText
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Text);
            }

            public bool IsSegSpec
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.SegSpec);
            }

            public bool IsSeg
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Seg);
            }

            public bool IsExpr
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Expr);
            }

            public string Format()
            {
                var dst = Kind.ToString();

                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CellClass(RuleCellKind src)
                => new CellClass(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCellKind(CellClass src)
                => src.Kind;
        }
   }
}