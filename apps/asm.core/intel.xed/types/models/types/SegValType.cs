//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        /// <summary>
        /// Specifies the data typeof a <see cref='FieldSeg'/>
        /// </summary>
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct SegValType : IFieldType<SegValType>
        {
            public const TypeKind Kind = TypeKind.SegVal;

            public readonly FieldSeg Seg;

            public readonly TypeKey DataType;

            [MethodImpl(Inline)]
            public SegValType(FieldSeg seg, TypeKey type)
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