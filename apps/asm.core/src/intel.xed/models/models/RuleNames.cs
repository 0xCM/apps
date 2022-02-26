//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [LiteralProvider("xed.names.rules")]
        internal readonly struct RuleNames
        {
            public const string ICLASS = nameof(ICLASS);

            public const string IFORM = nameof(IFORM);

            public const string ATTRIBUTES = nameof(ATTRIBUTES);

            public const string CATEGORY = nameof(CATEGORY);

            public const string EXTENSION = nameof(EXTENSION);

            public const string FLAGS = nameof(FLAGS);

            public const string PATTERN = nameof(PATTERN);

            public const string OPERANDS = nameof(OPERANDS);

            public const string ISA_SET = nameof(ISA_SET);
        }
    }
}
