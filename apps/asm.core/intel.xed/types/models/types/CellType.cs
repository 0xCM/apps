//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct CellType : IDataType<CellType>
        {
            public const TypeKind Kind = TypeKind.Cell;

            public readonly TypeKey Key;

            public readonly asci16 TypeName;

            public readonly TypeKey Base;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public CellType(TypeKey key, asci16 type, TypeKey @base, DataSize size)
            {
                Key = key;
                TypeName = type;
                Base = @base;
                Size = size;
            }

            TypeKind IDataType.Kind
                => Kind;

            asci32 IDataType.Name
                => TypeName;
        }
    }
}