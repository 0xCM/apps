//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum CellDataKind : byte
        {
            [Symbol(RP.Empty)]
            None,

            [Symbol("base2")]
            BinaryLiteral,

            [Symbol("base10")]
            DecimalLiteral,

            [Symbol("base16")]
            HexLiteral,

            [Symbol("null")]
            Null,

            [Symbol("error")]
            Error,

            [Symbol("@")]
            Wildcard,

            [Symbol("default")]
            Default,

            [Symbol("text")]
            Text,

            [Symbol("field")]
            FieldValue,

            [Symbol("call")]
            Call = 128,

            [Symbol("bfseg")]
            BfSeg,

            [Symbol("bfspec")]
            BfSpec,

            [Symbol("nt")]
            Nonterminal,

        }
    }
}