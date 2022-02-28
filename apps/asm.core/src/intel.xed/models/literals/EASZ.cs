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
        /// J:\source\xed\xed\src\common\xed-operand-values-interface.c
        /// </summary>
        [SymSource(xed_state), DataWidth(3)]
        public enum EASZ : sbyte
        {
            None = 0,

            [Symbol("eamode16", "MODE=0")]
            EASZ16 = 1,

            [Symbol("eamode32", "MODE=1")]
            EASZ32 = 2,

            [Symbol("eamode64", "MODE=2")]
            EASZ64 = 3,

            [Symbol("eanot16", "MODE!=2")]
            EASZNot16 = 4,
        }
    }
}