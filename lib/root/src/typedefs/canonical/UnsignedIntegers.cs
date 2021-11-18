//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Typedefs
    {
        [TypeDef(Name)]
        public readonly struct UInt8Type : ISizedIntegerType
        {
            [Parser]
            public static Outcome parse(string src, out AsciStringType dst)
            {
                dst = default;
                return text.trim(src) == Name;
            }

            public const string Name = "uint8";

            public bool Signed => false;

            public BitWidth StorageWidth => 8;

            public BitWidth ContentWidth => 8;

            public Identifier TypeName => Name;

            public string Format() => Name;

            public override string ToString()
                => Format();
        }

        [TypeDef(Name)]
        public readonly struct UInt16Type : ISizedIntegerType
        {
            [Parser]
            public static Outcome parse(string src, out AsciStringType dst)
            {
                dst = default;
                return text.trim(src) == Name;
            }

            public const string Name = "uint16";

            public bool Signed => false;

            public BitWidth StorageWidth => 16;

            public BitWidth ContentWidth => 16;

            public Identifier TypeName => Name;

            public string Format() => Name;

            public override string ToString()
                => Format();
        }

        [TypeDef(Name)]
        public readonly struct UInt32Type : ISizedIntegerType
        {
            [Parser]
            public static Outcome parse(string src, out AsciStringType dst)
            {
                dst = default;
                return text.trim(src) == Name;
            }

            public const string Name = "uint32";

            public bool Signed => false;

            public BitWidth StorageWidth => 32;

            public BitWidth ContentWidth => 32;

            public Identifier TypeName => Name;

            public string Format() => Name;

            public override string ToString()
                => Format();
        }

        [TypeDef(Name)]
        public readonly struct UInt64Type : ISizedIntegerType
        {
            [Parser]
            public static Outcome parse(string src, out AsciStringType dst)
            {
                dst = default;
                return text.trim(src) == Name;
            }
            public const string Name = "uint32";

            public bool Signed => false;

            public BitWidth StorageWidth => 64;

            public BitWidth ContentWidth => 64;

            public Identifier TypeName => Name;

            public string Format() => Name;

            public override string ToString()
                => Format();
        }
    }
}