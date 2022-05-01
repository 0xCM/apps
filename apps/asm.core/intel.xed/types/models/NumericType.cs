//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct NumericType : IRuleType<NumericType>
        {
            public const uint MetaWidth = asci16.Size*8 + PrimalType.MetaWidth + 8;

            public readonly asci16 TypeName;

            public readonly PrimalType Base;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public NumericType(asci16 name, PrimalType @base, byte packed)
            {
                Base = @base;
                TypeName = name;
                PackedWidth = packed;
            }

            public asci16 BaseName
            {
                [MethodImpl(Inline)]
                get => Base.TypeName;
            }

            public AlignedWidth AlignedWidth
            {
                [MethodImpl(Inline)]
                get => Base.Width;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.Numeric;
            }

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}