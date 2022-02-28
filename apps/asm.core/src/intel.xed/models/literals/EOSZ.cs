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
        /// Defines symbols to represent effective operands sizes
        /// </summary>
        [SymSource(xed_state), DataWidth(3)]
        public enum EOSZ : sbyte
        {
            [Symbol("eosz8", "EOSZ=0")]
            EOSZ8 = 0,

            [Symbol("eosz16", "EOSZ=1")]
            EOSZ16 = 1,

            [Symbol("eosz32", "EOSZ=2")]
            EOSZ32 = 2,

            [Symbol("eosz64", "EOSZ=3")]
            EOSZ64 = 3,

            [Symbol("not_eosz16", "EOSZ!=1")]
            EOSZNot16 = 5,

            [Symbol("eosznot64", "EOSZ!=3")]
            EOSZNot64 = 6
        }
    }
}