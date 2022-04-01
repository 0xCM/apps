//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum OpClass : byte
        {
            None,

            Action = 1,

            Width = 2,

            Visibility = 4,

            Nonterminal = 8,

            RegLiteral = 16,

            Scale = 32,

            ElementType = 64,

            Modifier = 128,
        }
    }
}