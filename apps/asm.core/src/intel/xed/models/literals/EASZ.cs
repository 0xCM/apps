//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-cpuid-bit-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// Defines symbols to represent effective addressing mode sizes, from all-state.txt
        /// </summary>
        [SymSource(xed)]
        public enum EASZ : sbyte
        {
            None = 0,

            [Symbol("eamode16"), Alias("a16")]
            easz16 = 1,

            [Symbol("eamode32"), Alias("a32")]
            easz32 = 2,

            [Symbol("eamode64"), Alias("a64")]
            easz64 = 3,
        }
    }
}