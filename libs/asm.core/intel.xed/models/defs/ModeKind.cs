//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(4)]
        public enum ModeKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("32/64", "64b operating mode")]
            LONG_64,

            [Symbol("32/64", "32b protected mode")]
            LONG_COMPAT_32,

            [Symbol("32/64", "16b protected mode")]
            LONG_COMPAT_16,

            [Symbol("32/64", "32b protected mode")]
            LEGACY_32,

            [Symbol("32/64", "16b protected mode")]
            LEGACY_16,

            [Symbol("32/64", "16b real mode")]
            REAL_16,

            [Symbol("32/64", "32b real mode (CS.D bit = 1)")]
            REAL_32,
        }
    }
}