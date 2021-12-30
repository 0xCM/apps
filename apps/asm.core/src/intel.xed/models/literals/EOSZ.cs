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
        [SymSource(state)]
        public enum EOSZ : sbyte
        {
            [Symbol("eosz8", "EOSZ=0")]
            EOSZ8 = 0,

            [Symbol("eosz16", "EOSZ=1")]
            EAOSZ16 = 1,

            [Symbol("eosz32", "EOSZ=2")]
            EAOSZ32 = 2,

            [Symbol("eosz64", "EOSZ=3")]
            EAOSZ64 = 3,

            [Symbol("not_eosz16", "EOSZ!=1")]
            Not16 = 5,

            [Symbol("eosznot64", "EOSZ!=3")]
            Not64 = 6
        }
    }
}