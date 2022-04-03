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

            public string Format()
                => IsNonEmpty ? XedRender.format(Kind) : EmptyString;

            public override string ToString()
                => Format();

            public static BfSpec Empty => new BfSpec(0);
        }
    }
}