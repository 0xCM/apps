//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed), DataWidth(num4.Width)]
        public enum OpAttribKind : byte
        {
            None,

            Action,

            Width,

            Visibility,

            Nonterminal,

            RegLiteral,

            Scale,

            ElementType,

            Modifier,
        }
    }
}