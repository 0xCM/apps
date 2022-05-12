//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum RuleCellKind : byte
        {
            [Symbol("<?>")]
            Void = 0,

            [Symbol("bit")]
            BitVal,

            [Symbol("int")]
            IntVal,

            [Symbol("hex")]
            HexVal,

            [Symbol("0b")]
            BitLiteral,

            [Symbol("0x")]
            HexLiteral,

            [Symbol("SegV")]
            SegVar,

            [Symbol("SegF")]
            FieldSeg,

            [Symbol("Kw")]
            Keyword,

            [Symbol("NtC")]
            NontermCall,

            [Symbol("OpX")]
            Operator,

            [Symbol("SegI")]
            InstSeg,

            [Symbol("NeqX")]
            NeqExpr,

            [Symbol("EqX")]
            EqExpr,

            [Symbol("NtX")]
            NontermExpr,

            [Symbol("vW")]
            WidthVar,
        }
   }
}