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
            None = 0,

            Action = 1,

            OpWidth = 2,

            Visibility = 3,

            PtrWidth = 4,

            Nonterminal,

            RegLiteral,

            Scale,

            ElementType,

            Modifier,
        }
    }
}