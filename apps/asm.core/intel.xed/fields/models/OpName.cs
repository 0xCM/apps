//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        public readonly struct OpName
        {
            public readonly OpNameKind Kind;

            [MethodImpl(Inline)]
            public OpName(OpNameKind src)
            {
                Kind = src;
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
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OpName(OpNameKind src)
                => new OpName(src);

            [MethodImpl(Inline)]
            public static implicit operator OpNameKind(OpName src)
                => src.Kind;

            public static OpName Empty => default;
        }
    }
}