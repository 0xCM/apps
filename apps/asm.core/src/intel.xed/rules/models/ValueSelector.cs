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
        public readonly struct ValueSelector
        {
            public readonly ushort Spec;

            public readonly ValueSelectorKind Kind;

            readonly byte Pad;

            [MethodImpl(Inline)]
            public ValueSelector(byte literal)
            {
                Spec = (ushort)literal;
                Kind = ValueSelectorKind.Literal;
                Pad = 0;
            }

            [MethodImpl(Inline)]
            public ValueSelector(EncodingGroup src)
            {
                Spec = (ushort)src;
                Kind = ValueSelectorKind.EncodingGroup;
                Pad = 0;
            }

            [MethodImpl(Inline)]
            public ValueSelector(NonterminalKind src)
            {
                Spec = (ushort)src;
                Kind = ValueSelectorKind.Nonterminal;
                Pad = 0;
            }

            [MethodImpl(Inline)]
            public ValueSelector(XedRegId src)
            {
                Spec = (ushort)src;
                Kind = ValueSelectorKind.RegLiteral;
                Pad = 0;
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

            public string Format()
                => XedFormatters.format(this);

             public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ValueSelector(EncodingGroup src)
                => new ValueSelector(src);

            [MethodImpl(Inline)]
            public static implicit operator ValueSelector(NonterminalKind src)
                => new ValueSelector(src);

            [MethodImpl(Inline)]
            public static implicit operator ValueSelector(byte src)
                => new ValueSelector(src);

            [MethodImpl(Inline)]
            public static implicit operator ValueSelector(XedRegId src)
                => new ValueSelector(src);

            public static ValueSelector Empty => default;
        }
    }
}