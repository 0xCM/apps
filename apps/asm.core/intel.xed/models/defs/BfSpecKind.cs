//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum BfSpecKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("w")]
            w,

            [Symbol("r")]
            r,

            [Symbol("x")]
            x,

            [Symbol("b")]
            b,

            [Symbol("ssss_dddd")]
            ssss_dddd,

            [Symbol("ss_iii_bbb")]
            ss_iii_bbb,

            [Symbol("z_nn_b")]
            z_nn_b,

            [Symbol("aaa")]
            aaa,

            [Symbol("u_ddd")]
            u_ddd,

            [Symbol("1_ddd")]
            _1_ddd,

            [Symbol("_?_")]
            Unknown
        }
    }
}