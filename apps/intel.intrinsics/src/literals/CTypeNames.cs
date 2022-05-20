//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct CTypeNames
    {
        public const string @char = "char";

        public const string @short = "short";

        public const string @int = "int";

        public const string @long = "long";

        public const string size_t = nameof(size_t);

        public const string @float = "float";

        public const string @double = "double";

        public const string @void = "void";

    }
}