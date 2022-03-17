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

            [Symbol("field")]
            FieldValue,

            [Symbol("literal")]
            Literal,

            [Symbol("call")]
            Call,

            [Symbol("bfseg")]
            BfSeg,

            [Symbol("bfspec")]
            BfSpec,

            [Symbol("null")]
            Null,

            [Symbol("error")]
            Error,

            [Symbol("@")]
            Wildcard,

            [Symbol("otherwise")]
            Default,
        }
    }
}