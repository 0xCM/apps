//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public struct Category
        {
            public CategoryKind Value {get;set;}

            [MethodImpl(Inline)]
            public Category(CategoryKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.format(Value) : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Category(CategoryKind src)
                => new Category(src);

            [MethodImpl(Inline)]
            public static implicit operator CategoryKind(Category src)
                => src.Value;
        }
    }
}