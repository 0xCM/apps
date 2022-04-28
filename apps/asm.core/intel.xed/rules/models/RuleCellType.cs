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
        public readonly record struct RuleCellType : IComparable<RuleCellType>
        {
            public readonly RuleCellKind Kind;

            [MethodImpl(Inline)]
            public RuleCellType(RuleCellKind kind)
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
            public int CompareTo(RuleCellType src)
                => ((byte)Kind).CompareTo((byte)src.Kind);

            public string Format()
                => XedRender.format(Kind);

            public override int GetHashCode()
                => (int)Kind;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RuleCellType(RuleCellKind src)
                => new RuleCellType(src);

            [MethodImpl(Inline)]
            public static implicit operator RuleCellKind(RuleCellType src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(RuleCellType src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator RuleCellType(byte src)
                => new RuleCellType((RuleCellKind)src);

            public static RuleCellType Empty => default;
        }
   }
}