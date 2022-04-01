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

            [Symbol("ssss_dddd")]
            UImmEsrc,

            [Symbol("ss_iii_bbb")]
            Sib,

            Unknown
        }
    }
}