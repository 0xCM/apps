//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = XedDataTypes.PrimalType.Intrinsic;

    public partial class XedDataTypes
    {
        /// <summary>
        /// Defines a type that can produce anonymous or named <see cref='PrimalType'/> values
        /// </summary>
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct LiteralType : IRuleType<LiteralType>
        {
            public const uint MetaWidth = TypeKey.MetaWidth + asci32.Size*8 + PrimalType.MetaWidth + PrimalType.W8;

            public const RuleTypeKind TypeKind = RuleTypeKind.Literal;

            public readonly struct Intrinsic
            {
                /// <summary>
                /// Specifies runtime literal types that are considered intrinsic and which correspond to the
                /// sorts defined byte <see cref='PrimalKind'/>
                /// </summary>
                public static Type[] ClrIntrinsic => new Type[]{
                    typeof(Null),
                    typeof(bit),
                    typeof(byte),
                    typeof(ushort),
                    typeof(uint),
                    typeof(long),
                    typeof(void),
                };

                public static LiteralType Null => literal(P.Empty.Key, P.Empty.TypeName, P.Empty, 0);

                public static LiteralType U1 => literal(P.U1.Key, P.U1.TypeName, P.U1, 1);

                public static LiteralType U8 => literal(P.U8.Key, P.U8.TypeName, P.U8, P.U8.Width);

                public static LiteralType U16 => literal(P.U16.Key, P.U16.TypeName, P.U16, P.U16.Width);

                public static LiteralType U32 => literal(P.U32.Key, P.U32.TypeName, P.U32, P.U32.Width);

                public static LiteralType U64 => literal(P.U64.Key, P.U64.TypeName, P.U64, P.U64.Width);

                public static LiteralType Void => literal(P.Void.Key, P.Void.TypeName, P.Void, 0);

                public static Intrinsic Types => new();

                public static implicit operator Index<PrimalKind,LiteralType>(Intrinsic src)
                    => _Types;

                static LiteralType[] _Types = new LiteralType[]
                {
                    Null,
                    U1,
                    U8,
                    U16,
                    U32,
                    U64,
                    Void,
                };
            }

            public readonly TypeKey Key;

            public readonly asci32 TypeName;

            public readonly PrimalType Base;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public LiteralType(TypeKey id, asci32 name, PrimalType @base, byte packed)
            {
                Key = id;
                TypeName = name;
                Base = @base;
                PackedWidth = packed;
            }

            public string Format()
                => TypeName;

            public override string ToString()
                => Format();

            public byte AlignedWidth
            {
                [MethodImpl(Inline)]
                get => Base.Width;
            }

            RuleTypeKind IRuleType.TypeKind
                => TypeKind;

            asci32 IRuleType.TypeName
                => TypeName;
        }
    }
}