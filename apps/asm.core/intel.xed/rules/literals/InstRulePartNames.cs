//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [LiteralProvider("xed.names.instructions.rules")]
        internal readonly struct InstRulePartNames
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

            public const string COMMENT = nameof(COMMENT);
        }
    }
}
