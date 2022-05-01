//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct PrimalType : IRuleType<PrimalType>
        {
            public const uint MetaWidth = W8 + asci16.Size*8 + AlignedWidth.MetaWidth;

            public const RuleTypeKind TypeKind = RuleTypeKind.Primitive;

            public const PrimalKind LastKind = PrimalKind.Void;

            public const byte W0 = 0;

            public const byte W1 = 8;

            public const byte W8 = 8;

            public const byte W16 = 16;

            public const byte W32 = 32;

            public const byte W64 = 64;


            public readonly struct Intrinsic
            {
                public static PrimalType Empty => primitive(PrimalKind.None, EmptyString, W0);

                public static PrimalType U1 => primitive(PrimalKind.U1, "bit", W1);

                public static PrimalType U8 => primitive(PrimalKind.U8, "byte", W8);

                public static PrimalType U16 => primitive(PrimalKind.U16, "ushort", W16);

                public static PrimalType U32 => primitive(PrimalKind.U32, "uint", W32);

                public static PrimalType U64 => primitive(PrimalKind.U64, "ulong", W64);

                public static PrimalType Void => primitive(PrimalKind.Void, "void", W0);

                public static Intrinsic Types => new();

                [MethodImpl(Inline)]
                public static ref readonly PrimalType type(PrimalKind kind)
                {
                    if(kind <= LastKind)
                        return ref core.skip(_Types,(byte)kind);
                    else
                        return ref core.first(_Types);
                }

                public static implicit operator Index<PrimalKind,PrimalType>(Intrinsic src)
                    => _Types;

                static PrimalType[] _Types = new PrimalType[]{
                    Empty,
                    U1,
                    U8,
                    U16,
                    U32,
                    U64,
                    Void,
                };
            }

            [MethodImpl(Inline)]
            public static ref readonly PrimalType type(PrimalKind kind)
                => ref Intrinsic.type(kind);

            public readonly PrimalKind Kind;

            public readonly asci16 TypeName;

            public readonly byte Width;

            [MethodImpl(Inline)]
            public PrimalType(PrimalKind kind, asci16 name, AlignedWidth width)
            {
                Kind = kind;
                TypeName = name;
                Width = (byte)(width.Size*8);
            }

            public string Format()
                => TypeName;

            public override string ToString()
                => Format();

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public TypeKey Key
            {
                [MethodImpl(Inline)]
                get => (byte)Kind;
            }

            RuleTypeKind IRuleType.TypeKind
                => TypeKind;

            asci32 IRuleType.TypeName
                => TypeName;

            public static PrimalType Empty => Intrinsic.Empty;
        }
    }
}