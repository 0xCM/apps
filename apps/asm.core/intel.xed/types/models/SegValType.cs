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
            public const uint MetaWidth = SegField.MetaWidth + TypeKey.MetaWidth;

            public const TypeKind Kind = TypeKind.SegVal;

            public readonly SegField Seg;

            public readonly TypeKey DataType;

            [MethodImpl(Inline)]
            public SegValType(SegField seg, TypeKey type)
            {
                Seg = seg;
                DataType = type;
            }

            TypeKind IRuleType.TypeKind
                => Kind;

            FieldKind IFieldType.Field
                => Seg.Field;

            asci32 IRuleType.TypeName
                => XedRender.format(Seg.Field);
        }
    }
}