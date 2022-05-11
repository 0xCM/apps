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
        public readonly struct SegVarType : IFieldType<SegVarType>
        {
            public const TypeKind Kind = TypeKind.SegVar;

            public readonly FieldSeg Seg;

            public readonly TypeKey DataType;

            [MethodImpl(Inline)]
            public SegVarType(FieldSeg seg, TypeKey type)
            {
                Seg = seg;
                DataType = type;
            }

            TypeKind IDataType.Kind
                => Kind;

            FieldKind IFieldType.Field
                => Seg.Field;

            asci32 IDataType.Name
                => XedRender.format(Seg.Field);
        }
    }
}