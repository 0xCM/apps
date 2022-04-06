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
        public readonly struct BfSpec
        {
            public readonly BfSpecKind Kind;

            [MethodImpl(Inline)]
            public BfSpec(BfSpecKind kind)
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

            public asci16 Pattern
                => XedRender.format(Kind);

            public string Format()
                => Pattern;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator byte(BfSpec src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator BfSpec(byte src)
                => new BfSpec((BfSpecKind)src);

            public static BfSpec Empty => new BfSpec(0);
        }
    }
}