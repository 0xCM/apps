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
            public const uint MetaWidth = asci32.Size*8 + TypeKey.MetaWidth + PrimalType.W8;

            public const TypeKind Kind = TypeKind.TypedLiteral;

            public readonly asci32 LiteralName;

            public readonly TypeKey Base;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public TypedLiteral(asci32 literal, TypeKey @base, byte packed)
            {
                LiteralName = literal;
                Base = @base;
                PackedWidth = packed;
            }

            TypeKind IRuleType.TypeKind
                => Kind;

            asci32 IRuleType.TypeName
                => LiteralName;
        }
    }
}