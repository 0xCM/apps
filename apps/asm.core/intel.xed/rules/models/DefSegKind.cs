//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum DefSegKind : byte
        {
            None,

            HexLiteral,

            IntLiteral,

            Bitfield,

            BitLiteral,

            Nonterm,

            FieldLiteral,

            FieldAssign,

            Constraint,
        }
    }
}