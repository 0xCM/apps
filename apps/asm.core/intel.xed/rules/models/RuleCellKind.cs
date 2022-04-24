//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(4,8)]
        public enum RuleCellKind : byte
        {
            [Symbol("<?>")]
            Void = 0,

            [Symbol("0b")]
            BitLiteral,

            [Symbol("0i")]
            IntLiteral,

            [Symbol("0x")]
            HexLiteral,

            [Symbol("SegV")]
            SegVar,

            [Symbol("Kw")]
            Keyword,

            [Symbol("NtC")]
            NontermCall,

            [Symbol("OpX")]
            Operator,

            [Symbol("SegF")]
            SegField,

            [Symbol("NeqX")]
            NeqExpr,

            [Symbol("EqX")]
            EqExpr,

            [Symbol("NtX")]
            NontermExpr,
        }
   }
}