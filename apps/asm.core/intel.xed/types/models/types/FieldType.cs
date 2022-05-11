//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct FieldType : IFieldType<FieldType>
        {
            public const TypeKind Kind = TypeKind.Field;

            public readonly FieldKind Field;

            public readonly CellType DataType;

            [MethodImpl(Inline)]
            public FieldType(FieldKind field, CellType cell)
            {
                Field = field;
                DataType = cell;
            }

            TypeKind IDataType.Kind
                => Kind;

            FieldKind IFieldType.Field
                => Field;

            asci32 IDataType.Name
                => DataType.TypeName;
        }
    }
}