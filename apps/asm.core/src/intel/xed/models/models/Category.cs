//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        [DataType(Names.category)]
        public readonly struct Category : IEnumCover<CategoryKind>
        {
            public CategoryKind Value {get;}

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
            public static implicit operator Category(EnumCover<CategoryKind> src)
                => new Category(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator Category(CategoryKind src)
                => new Category(src);

            [MethodImpl(Inline)]
            public static implicit operator CategoryKind(Category src)
                => src.Value;
        }
    }
}