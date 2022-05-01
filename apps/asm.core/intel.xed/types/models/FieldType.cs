//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct FieldType : IFieldType<FieldType>
        {
            internal const uint MetaWidth = 8 + CellType.MetaWidth;

            public readonly FieldKind Field;

            public readonly CellType DataType;

            [MethodImpl(Inline)]
            public FieldType(FieldKind field, CellType cell)
            {
                Field = field;
                DataType = cell;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.Field;
            }

            FieldKind IFieldType.Field
                => Field;

            asci32 IRuleType.TypeName
                => DataType.TypeName;
        }
    }
}