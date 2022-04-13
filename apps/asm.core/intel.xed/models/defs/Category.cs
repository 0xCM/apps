//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(8)]
        public readonly record struct Category
        {
            public readonly CategoryKind Kind;

            [MethodImpl(Inline)]
            public Category(CategoryKind src)
            {
                Kind = src;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Category(CategoryKind src)
                => new Category(src);

            [MethodImpl(Inline)]
            public static implicit operator CategoryKind(Category src)
                => src.Kind;

            public static Category Empty => default;
        }
    }
}