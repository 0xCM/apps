//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        public enum ColKind : byte
        {
            None,

            [Symbol("bit")]
            Bit,

            [Symbol("byte")]
            U8,

            [Symbol("ushort")]
            U16,

            [Symbol("uint")]
            U32,

            [Symbol("ulong")]
            U64,

            [Symbol("indicator")]
            Indicator,

            [Symbol("Char5")]
            Char5,

            [Symbol("char")]
            Char8,

            [Symbol("asci8")]
            Asci8,

            [Symbol("asci16")]
            Asci16,

            [Symbol("asci32")]
            Asci32,

            [Symbol("asci64")]
            Asci64,

            Relation,

            TableType,

            TableSeq,
        }
    }
}