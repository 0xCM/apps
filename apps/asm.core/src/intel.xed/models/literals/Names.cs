//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [LiteralProvider("xed.names.models")]
        public readonly struct XedNames
        {
            const string xed = "xed.";

            public const string nonterminal = xed + nameof(nonterminal);

            public const string reg = xed + nameof(reg);

            public const string basetype = xed + nameof(basetype);

            public const string iform = xed + nameof(iform);

            public const string extension = xed + nameof(extension);

            public const string category = xed + nameof(category);
        }
    }
}
