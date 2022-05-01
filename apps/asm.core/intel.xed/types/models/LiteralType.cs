//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct LiteralType : IRuleType<LiteralType>
        {
            internal const uint MetaWidth = asci16.Size*8 + DataSize.StorageWidth;

            public readonly asci16 TypeName;

            public readonly PrimalType Base;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public LiteralType(asci16 name, PrimalType @base, byte packed)
            {
                TypeName = name;
                Base = @base;
                PackedWidth = packed;
            }

            public AlignedWidth AlignedWidth
            {
                [MethodImpl(Inline)]
                get => Base.Width;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.Literal;
            }

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}