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

            Common,

            Action,

            OpWidth,

            PtrWidth,

            Nonterminal,

            RegLiteral,

            Scale,

            RegResolver,

            DataType,

            Visibility,

            Macro,

            EncodingGroup,

            TextProp,


        }
    }
}