//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-OperandElementType-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;

    partial struct XedModels
    {
        [DataType(Names.basetype)]
        public struct BaseType : IEnumCover<BaseTypeKind>
        {
            public BaseTypeKind Value {get;set;}

            [MethodImpl(Inline)]
            public BaseType(BaseTypeKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.expr(Value).Format() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator BaseType(EnumCover<BaseTypeKind> src)
                => new BaseType(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator BaseType(BaseTypeKind src)
                => new BaseType(src);

            [MethodImpl(Inline)]
            public static implicit operator BaseTypeKind(BaseType src)
                => src.Value;
        }
    }
}