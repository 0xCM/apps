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
            public const uint MetaWidth = PrimalType.W8 + CellType.MetaWidth;

            public const RuleTypeKind TypeKind = RuleTypeKind.Field;

            public readonly FieldKind Field;

            public readonly CellType DataType;

            [MethodImpl(Inline)]
            public FieldType(FieldKind field, CellType cell)
            {
                Field = field;
                DataType = cell;
            }

            RuleTypeKind IRuleType.TypeKind
                => TypeKind;

            FieldKind IFieldType.Field
                => Field;

            asci32 IRuleType.TypeName
                => DataType.TypeName;
        }
    }
}