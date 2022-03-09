//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state)]
        public enum RoundingKind : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("{rn-sae}","Round to nearest, ties to even, suppress all exceptions")]
            RnSae,

            [Symbol("{rd-sae}","Round down (toward negative infinity), suppress all exceptions")]
            RdSae,

            [Symbol("{ru-sae}","Round up (toward positive infinity), suppress all exception")]
            RuSae,

            [Symbol("{rz-sae}","Round toward zero, suppress all exception")]
            RzSae,
        }
    }
}
