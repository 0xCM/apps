//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedNames;

    partial struct XedModels
    {
        public enum VexLengthKind
        {
            [Symbol(N.VL128, "Specifies a vector length of 128")]
            VL128 = 0,

            [Symbol(N.VL256, "Specifies a vector length of 256")]
            VL256 = 1,

            [Symbol(N.VL512, "Specifies a vector length of 512")]
            VL512 = 2,
        }
    }
}