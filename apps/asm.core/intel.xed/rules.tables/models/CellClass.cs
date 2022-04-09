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

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Kind.Test(K.Operator);
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