//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum DefFieldClass : byte
        {
            None,

            BitLiteral,

            HexLiteral,

            IntLiteral,

            Seg,

            Nonterm,

            FieldExpr,
        }
    }
}