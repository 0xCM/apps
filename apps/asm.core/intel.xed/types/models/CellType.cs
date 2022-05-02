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
            public const uint MetaWidth = TypeKey.MetaWidth + asci16.Size*8 + TypeKey.MetaWidth + PrimalType.W8;

            public const TypeKind Kind = TypeKind.Cell;

            public readonly TypeKey Key;

            public readonly asci16 TypeName;

            public readonly TypeKey Base;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public CellType(TypeKey key, asci16 type, TypeKey @base, byte packed)
            {
                Key = key;
                TypeName = type;
                Base = @base;
                PackedWidth = packed;
            }

            TypeKind IRuleType.TypeKind
                => Kind;

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}