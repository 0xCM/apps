//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct CellType : IDataType<CellType>
        {
            public readonly TypeKey Key;

            public readonly asci64 TypeName;

            public readonly TypeKey Base;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public CellType(TypeKey key, asci64 type, TypeKey @base, DataSize size)
            {
                Key = key;
                TypeName = type;
                Base = @base;
                Size = size;
            }

            asci64 IDataType.Name
                => TypeName;

            DataSize IDataType.Size
                => Size;
        }
    }
}