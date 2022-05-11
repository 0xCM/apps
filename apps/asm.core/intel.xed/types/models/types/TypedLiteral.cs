//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct TypedLiteral : IDataType<TypedLiteral>
        {
            public const TypeKind Kind = TypeKind.TypedLiteral;

            public readonly asci32 LiteralName;

            public readonly TypeKey Base;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public TypedLiteral(asci32 literal, TypeKey @base, DataSize size)
            {
                LiteralName = literal;
                Base = @base;
                Size = size;
            }

            TypeKind IDataType.Kind
                => Kind;

            asci32 IDataType.Name
                => LiteralName;
        }
    }
}