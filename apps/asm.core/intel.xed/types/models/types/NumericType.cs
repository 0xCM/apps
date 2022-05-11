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
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct NumericType : IDataType<NumericType>
        {
            public const TypeKind Kind = TypeKind.Numeric;

            public readonly TypeKey Key;

            public readonly asci16 TypeName;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public NumericType(TypeKey key, asci16 name, DataSize size)
            {
                Key = key;
                TypeName = name;
                Size = size;
            }

            [MethodImpl(Inline)]
            public NumericType(TypeKey key, asci16 name, byte packed)
            {
                Key = key;
                TypeName = name;
                var x = (uint)packed;
                Size = new DataSize((uint)packed, x % 8 == 0 ? x/8 : (x/8) + 1);
            }

            public string Format()
                => TypeName;

            public override string ToString()
                => Format();

            asci32 IDataType.Name
                => TypeName;

            TypeKind IDataType.Kind
                => Kind;

            public static NumericType Empty => Intrinsic.None;

            public readonly struct Intrinsic
            {
                public static NumericType None => numeric(NextKey(TypeKind.Numeric),  P.Empty.TypeName, 0);

                public static NumericType U1 => numeric(NextKey(TypeKind.Numeric),  P.U1.TypeName, (1,8));

                public static NumericType U8 => numeric(NextKey(TypeKind.Numeric),  P.U8.TypeName, 8);

                public static NumericType U16 => numeric(NextKey(TypeKind.Numeric), P.U16.TypeName, 16);

                public static NumericType U32 => numeric(NextKey(TypeKind.Numeric), P.U32.TypeName, 32);

                public static NumericType U64 => numeric(NextKey(TypeKind.Numeric),  P.U64.TypeName, 64);

                public static NumericType U2 => numeric(NextKey(TypeKind.Numeric),  nameof(uint2), (2,8));

                public static NumericType U3 => numeric(NextKey(TypeKind.Numeric),  nameof(uint3), (3,8));

                public static NumericType U4 => numeric(NextKey(TypeKind.Numeric),  nameof(uint4), (4,8));

                public static NumericType U5 => numeric(NextKey(TypeKind.Numeric),  nameof(uint5), (5,8));

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
        }
    }
}