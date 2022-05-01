//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct TypedLiteral : IRuleType<TypedLiteral>
        {
            public const uint MetaWidth = asci32.Size*8 + LiteralType.MetaWidth + 8;

            public readonly asci32 TypeName;

            public readonly LiteralType Base;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public TypedLiteral(asci32 name, LiteralType @base, byte packed)
            {
                TypeName = name;
                Base = @base;
                PackedWidth = packed;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.TypedLiteral;
            }

            public AlignedWidth AlignedWidth
            {
                [MethodImpl(Inline)]
                get => Base.AlignedWidth;
            }

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}