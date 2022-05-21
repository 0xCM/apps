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
        public readonly record struct SegVarType : IFieldType<SegVarType>
        {
            public readonly FieldSeg Seg;

            public readonly TypeKey DataType;

            [MethodImpl(Inline)]
            public SegVarType(FieldSeg seg, TypeKey type)
            {
                Seg = seg;
                DataType = type;
            }

            DataSize IDataType.Size
                => default;

            FieldKind IFieldType.Field
                => Seg.Field;

            asci64 IDataType.Name
                => XedRender.format(Seg.Field);
        }
    }
}