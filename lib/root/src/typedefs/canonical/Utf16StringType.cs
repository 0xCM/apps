//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Typedefs
    {
        [TypeDef(Name)]
        public readonly struct Utf16StringType : ITypeDef
        {
            public const string Name = "utf16";

            public bool IsSized => false;

            public Identifier TypeName => Name;

            public string Format() => Name;

            public override string ToString()
                => Format();
        }

        [TypeDef(Name)]
        public readonly struct Utf16StringType<N> : INaturalStringType<N,Utf16StringType<N>>, ISizedType
            where N : unmanaged, ITypeNat
        {
            public const string Name = "utf16<{0}>";

            public uint Length => Typed.nat32u<N>();

            public BitWidth StorageWidth => Length*2;

            public BitWidth ContentWidth => Length*2;

            public bool IsSized => true;

            public Identifier TypeName => string.Format(Name, Length);

            public string Format() => TypeName;

            public override string ToString()
                => Format();
        }
    }
}