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
        public readonly struct SegFieldType : IFieldType<SegFieldType>
        {
            public const uint MetaWidth = FieldType.MetaWidth;

            public readonly FieldType Field;

            [MethodImpl(Inline)]
            public SegFieldType(FieldType field)
            {
                Field = field;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.SegField;
            }

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