//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataType(XedNames.basetype)]
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