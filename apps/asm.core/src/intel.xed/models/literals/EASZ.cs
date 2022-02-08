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
        [SymSource(xed_state)]
        public enum EASZ : sbyte
        {
            [Symbol("eamode16", "MODE=0")]
            EASZ16 = 0,

            [Symbol("eamode32", "MODE=1")]
            EASZ32 = 1,

            [Symbol("eamode64", "MODE=2")]
            EASZ64 = 2,

            [Symbol("eanot16", "MODE!=2")]
            EASZNot16 = 3,
        }
    }
}