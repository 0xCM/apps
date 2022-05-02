//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct FieldSegType : IFieldType<FieldSegType>
        {
            public const uint MetaWidth = FieldType.MetaWidth;

            public const TypeKind Kind = TypeKind.FieldSeg;

            public readonly FieldType Field;

            [MethodImpl(Inline)]
            public FieldSegType(FieldType field)
            {
                Field = field;
            }

            TypeKind IRuleType.TypeKind
                => Kind;

            public readonly CellType DataType
            {
                [MethodImpl(Inline)]
                get => Field.DataType;
            }

            FieldKind IFieldType.Field
                => Field.Field;

            asci32 IRuleType.TypeName
                => Field.DataType.TypeName;
        }
    }
}