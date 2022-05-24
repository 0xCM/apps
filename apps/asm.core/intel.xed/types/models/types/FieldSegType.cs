//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct FieldSegType : IFieldType<FieldSegType>
        {
            public readonly FieldType Field;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public FieldSegType(FieldType field, DataSize size)
            {
                Field = field;
                Size = size;
            }

            public readonly CellType FieldType
            {
                [MethodImpl(Inline)]
                get => Field.DataType;
            }

            DataSize IDataType.Size
                => Size;

            FieldKind IFieldType.Field
                => Field.Field;

            asci64 IDataType.Name
                => Field.DataType.TypeName;
        }
    }
}