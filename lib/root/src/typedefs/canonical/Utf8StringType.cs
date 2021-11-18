//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Typedefs
    {
        [TypeDef(Name)]
        public readonly struct Utf8StringType : ITypeDef
        {
            public static Outcome parse(string src, out AsciStringType dst)
            {
                dst = default;
                return text.trim(src) == Name;
            }

            public const string Name = "utf8";

            public bool IsSized => false;

            public Identifier TypeName => Name;
        }

        [TypeDef(Name)]
        public readonly struct Utf8StringType<N> : INaturalStringType<N,Utf8StringType<N>>
            where N : unmanaged, ITypeNat
        {
            public const string Name = "utf8<{0}>";

            public N Length => default;

            public Identifier TypeName => string.Format(Name, Length);

            public bool IsSized => false;
        }
    }
}