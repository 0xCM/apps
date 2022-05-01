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
        public readonly struct SegValType : IFieldType<SegValType>
        {
            public const uint MetaWidth = SegField.MetaWidth + CellType.MetaWidth;

            public readonly SegField Seg;

            public readonly CellType DataType;

            [MethodImpl(Inline)]
            public SegValType(SegField seg, CellType type)
            {
                Seg = seg;
                DataType = type;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.SegVal;
            }

            FieldKind IFieldType.Field
                => Seg.Field;

            asci32 IRuleType.TypeName
                => XedRender.format(Seg.Field);
        }
    }
}