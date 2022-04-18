//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(3)]
        public enum ModeKind : sbyte
        {
            [Symbol("16", "MODE=0")]
            Mode16 = 0,

            [Symbol("32", "MODE=1")]
            Mode32 = 1,

            [Symbol("64", "MODE=2")]
            Mode64 = 2,

            [Symbol("16/32", "MODE!=2")]
            Not64 = 3,

            [Symbol("32/64")]
            Default = 4,
        }

        /*
  XED_MACHINE_MODE_INVALID,
  XED_MACHINE_MODE_LONG_64, ///< 64b operating mode
  XED_MACHINE_MODE_LONG_COMPAT_32, ///< 32b protected mode
  XED_MACHINE_MODE_LONG_COMPAT_16, ///< 16b protected mode
  XED_MACHINE_MODE_LEGACY_32, ///< 32b protected mode
  XED_MACHINE_MODE_LEGACY_16, ///< 16b protected mode
  XED_MACHINE_MODE_REAL_16, ///< 16b real mode
  XED_MACHINE_MODE_REAL_32, ///< 32b real mode (CS.D bit = 1)
  XED_MACHINE_MODE_LAST

        */
    }
}