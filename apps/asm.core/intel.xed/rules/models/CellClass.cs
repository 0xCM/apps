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

            [MethodImpl(Inline)]
            public int CompareTo(CellClass src)
                => ((byte)Kind).CompareTo((byte)src.Kind);

            public string Format()
                => Kind.ToString();

            public override int GetHashCode()
                => (int)Kind;

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

           public static CellClass Empty => default;
        }
   }
}