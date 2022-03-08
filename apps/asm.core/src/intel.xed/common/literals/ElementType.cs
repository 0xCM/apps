//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ElementType
        {
            public readonly ElementKind Kind;

            [MethodImpl(Inline)]
            public ElementType(ElementKind kind)
            {
                Kind = kind;
            }

            public string Name
            {
                [MethodImpl(Inline)]
                get => XedFormatters.format(Kind);
            }

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ElementType(ElementKind src)
                => new ElementType(src);

            [MethodImpl(Inline)]
            public static implicit operator ElementKind(ElementType src)
                => src.Kind;
        }
    }
}