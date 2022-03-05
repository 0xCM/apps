//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum OperandAttribKind : byte
        {
            None,

            Action,

            OpWidth,

            PtrWidth,

            Nonterminal,

            RegLiteral,

            Scale,

            RegResolver,

            DataType,

            Supression,

            Macro,
        }
    }
}