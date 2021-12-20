//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-OperandElementType-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct ElementType : IEnumCover<ElementTypeKind>
        {
            public ElementTypeKind Value {get;}

            [MethodImpl(Inline)]
            public ElementType(ElementTypeKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.expr(Value).Format() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator ElementType(EnumCover<ElementTypeKind> src)
                => new ElementType(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator ElementType(ElementTypeKind src)
                => new ElementType(src);

            [MethodImpl(Inline)]
            public static implicit operator ElementTypeKind(ElementType src)
                => src.Value;
        }
    }
}