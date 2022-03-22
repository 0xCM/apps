//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public enum OpKind : byte
        {
            None,

            [Symbol("agen")]
            Agen,

            [Symbol("base")]
            Base,

            [Symbol("disp")]
            Disp,

            [Symbol("imm")]
            Imm,

            [Symbol("index")]
            Index,

            [Symbol("m")]
            Mem,

            [Symbol("ptr")]
            Ptr,

            [Symbol("r")]
            Reg,

            [Symbol("relbr")]
            RelBr,

            [Symbol("scale")]
            Scale,

            [Symbol("seg")]
            Seg,

            Macro,
        }
    }
}