//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct OpName : IComparable<OpName>
        {
            public readonly OpNameKind Kind;

            [MethodImpl(Inline)]
            public OpName(OpNameKind src)
            {
                Kind = src;
            }

            public OpIndicator Indicator
                => XedRules.indicator(Kind);

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

            [MethodImpl(Inline)]
            public int CompareTo(OpName src)
                => XedRules.cmp(Kind,src.Kind);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OpName(OpNameKind src)
                => new OpName(src);

            [MethodImpl(Inline)]
            public static implicit operator OpNameKind(OpName src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(OpName src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator OpName(byte src)
                => new OpName((OpNameKind)src);

            public static OpName Empty => default;
        }
    }
}