//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct FieldSegType : IFieldType<FieldSegType>
        {
            public const TypeKind Kind = TypeKind.FieldSeg;

            public readonly FieldType Field;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public FieldSegType(FieldType field, DataSize size)
            {
                Field = field;
                Size = size;
            }

            TypeKind IDataType.Kind
                => Kind;

            public readonly CellType FieldType
            {
                [MethodImpl(Inline)]
                get => Field.DataType;
            }

            FieldKind IFieldType.Field
                => Field.Field;

            asci32 IDataType.Name
                => Field.DataType.TypeName;
        }
    }
}