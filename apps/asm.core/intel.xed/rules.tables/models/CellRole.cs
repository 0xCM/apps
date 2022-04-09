//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [SymSource(xed)]
        public enum CellRole : byte
        {
            [Symbol("")]
            None,

            [Symbol("0b")]
            BinaryLiteral,

            [Symbol("d")]
            IntLiteral,

            [Symbol("0x")]
            HexLiteral,

            [Symbol("nt")]
            NontermCall,

            [Symbol("seg")]
            Seg,

            [Symbol("bfspec")]
            BfSpec,

            [Symbol("disp")]
            DispSpec,

            [Symbol("imm")]
            ImmSpec,

            Keyword,

            [Symbol("branch")]
            Branch,

            [Symbol("null")]
            Null,

            [Symbol("error")]
            Error,

            [Symbol("@")]
            Wildcard,

            [Symbol("default")]
            Default,

            [Symbol("nt(x)")]
            NontermExpr,

            FieldValue,
        }
   }
}