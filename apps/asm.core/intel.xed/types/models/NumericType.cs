//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using L = XedDataTypes.LiteralType.Intrinsic;
    using P = XedDataTypes.PrimalType.Intrinsic;

    partial class XedDataTypes
    {
        /// <summary>
        /// Defines either an intrinsic numeric type or a refinement of such
        /// </summary>
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct NumericType : IRuleType<NumericType>
        {
            public const uint MetaWidth = asci16.Size*8 + TypeKey.MetaWidth + PrimalType.W8;

            public const TypeKind Kind = TypeKind.Numeric;

            public readonly struct Intrinsic
            {
                public static NumericType None => numeric(NextKey(TypeKind.Numeric),  P.Empty.TypeName, (NumericWidth)L.Null.PackedWidth);

                public static NumericType U1 => numeric(NextKey(TypeKind.Numeric),  P.U1.TypeName, (NumericWidth)L.U1.PackedWidth);

                public static NumericType U8 => numeric(NextKey(TypeKind.Numeric),  P.U8.TypeName, (NumericWidth)L.U8.PackedWidth);

                public static NumericType U16 => numeric(NextKey(TypeKind.Numeric), P.U16.TypeName, (NumericWidth)L.U16.PackedWidth);

                public static NumericType U32 => numeric(NextKey(TypeKind.Numeric), P.U32.TypeName, (NumericWidth)L.U32.PackedWidth);

                public static NumericType U64 => numeric(NextKey(TypeKind.Numeric),  P.U64.TypeName, (NumericWidth)L.U64.PackedWidth);

                public static NumericType U2 => numeric(NextKey(TypeKind.Numeric),  nameof(uint2), NumericWidth.W2);

                public static NumericType U3 => numeric(NextKey(TypeKind.Numeric),  nameof(uint3), NumericWidth.W3);

                public static NumericType U4 => numeric(NextKey(TypeKind.Numeric),  nameof(uint4), NumericWidth.W4);

                public static NumericType U5 => numeric(NextKey(TypeKind.Numeric),  nameof(uint5), NumericWidth.W5);

                public static Intrinsic Types => new();

                public static implicit operator Index<NumericKind,NumericType>(Intrinsic src)
                    => _Types;

                static NumericType[] _Types = new NumericType[]{
                    None,
                    U1,
                    U8,
                    U16,
                    U32,
                    U64,
                    U2,
                    U3,
                    U4,
                    U5
                };
            }

            public readonly TypeKey Key;

            public readonly asci16 TypeName;

            public readonly NumericWidth Width;

            [MethodImpl(Inline)]
            public NumericType(TypeKey key, asci16 name, NumericWidth packed)
            {
                Key = key;
                TypeName = name;
                Width = packed;
            }

            public string Format()
                => TypeName;

            public override string ToString()
                => Format();

            asci32 IRuleType.TypeName
                => TypeName;

            TypeKind IRuleType.TypeKind
                => Kind;

            public static NumericType Empty => Intrinsic.None;
        }
    }
}