//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// Defines symbols to represent effective addressing modes
        /// </summary>
        [SymSource(state)]
        public enum EASZ : sbyte
        {
            [Symbol("eamode16", "MODE=0")]
            EaMode16 = 1,

            [Symbol("eamode32", "MODE=1")]
            EaMode32 = 2,

            [Symbol("eamode64", "MODE=2")]
            EaMode64 = 3,

            [Symbol("eanot16", "MODE!=2")]
            Not16,
        }
    }
}