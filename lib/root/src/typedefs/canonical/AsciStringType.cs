//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Typedefs
    {
        [TypeDef(Name)]
        public readonly struct AsciStringType : ITypeDef
        {
            [Parser]
            public static Outcome parse(string src, out AsciStringType dst)
            {
                dst = default;
                return text.trim(src) == Name;
            }

            public const string Name = "asci";

            public bool IsSized => false;

            public Identifier TypeName => Name;

            public string Format() => Name;

            public override string ToString()
                => Format();
        }

        [TypeDef(Name)]
        public readonly struct AsciStringType<N> : INaturalStringType<N,AsciStringType<N>>, ISizedType
            where N : unmanaged, ITypeNat
        {
            public const string Name = "asci<{0}>";

            public uint Length => Typed.nat32u<N>();

            public BitWidth StorageWidth => Length;

            public BitWidth ContentWidth => Length;

            public bool IsSized => true;

            public Identifier TypeName => string.Format(Name, Length);

            public string Format() => TypeName;

            public override string ToString()
                => Format();
        }
    }
}