//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct CellType : IRuleType<CellType>
        {
            internal const uint MetaWidth = asci16.Size*8 + PrimalType.MetaWidth + 8;

            public readonly asci16 TypeName;

            public readonly PrimalType Primitive;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public CellType(asci16 type, PrimalType prim, byte packed)
            {
                TypeName = type;
                Primitive = prim;
                PackedWidth = packed;
            }

            public asci16 PrimalName
            {
                [MethodImpl(Inline)]
                get => Primitive.TypeName;
            }

            public AlignedWidth AlignedWidth
            {
                [MethodImpl(Inline)]
                get => Primitive.Width;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.Cell;
            }

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}