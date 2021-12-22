//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = XedModels;

    partial struct XedModels
    {
        [SymSource(xed)]
        public enum RuleDocKind : byte
        {
            [Symbol("all-enc-instructions")]
            EncInstDef,
        }


        [LiteralProvider("xed.names.rules")]
        internal readonly struct RuleNames
        {
            public const string ICLASS = nameof(ICLASS);

            public const string ATTRIBUTES = nameof(ATTRIBUTES);

            public const string CATEGORY = nameof(CATEGORY);

            public const string EXTENSION = nameof(EXTENSION);

            public const string FLAGS = nameof(FLAGS);

            public const string PATTERN = nameof(PATTERN);

            public const string OPERANDS = nameof(OPERANDS);
        }
    }
}
