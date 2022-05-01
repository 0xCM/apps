//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct PrimalType : IRuleType<PrimalType>
        {
            public const uint MetaWidth = asci16.Size*8 + AlignedWidth.MetaWidth;

            public readonly asci16 TypeName;

            public readonly AlignedWidth Width;

            [MethodImpl(Inline)]
            public PrimalType(asci16 name, AlignedWidth width)
            {
                TypeName = name;
                Width = width;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.Primitive;
            }

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}