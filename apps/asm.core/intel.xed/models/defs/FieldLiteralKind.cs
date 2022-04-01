//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum FieldLiteralKind : byte
        {
            None,

            [Symbol("base16")]
            HexLiteral,

            [Symbol("base2")]
            BinaryLiteral,

            [Symbol("base10")]
            DecimalLiteral,

            [Symbol("@")]
            Wildcard,

            [Symbol("null")]
            Null,

            [Symbol("default")]
            Default,

            [Symbol("error")]
            Error,

            [Symbol("text")]
            Text,
        }
    }
}