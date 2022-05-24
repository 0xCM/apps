//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct FieldType : IFieldType<FieldType>
        {
            public readonly FieldKind Field;

            public readonly CellType DataType;

            [MethodImpl(Inline)]
            public FieldType(FieldKind field, CellType cell)
            {
                Field = field;
                DataType = cell;
            }

            DataSize IDataType.Size
                => DataType.Size;

            FieldKind IFieldType.Field
                => Field;

            asci64 IDataType.Name
                => DataType.TypeName;
        }
    }
}