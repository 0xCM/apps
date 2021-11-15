//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-class.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// Derived from xed-state-bits.txt
        /// </summary>
        [SymSource(xed)]
        public enum SAMode : sbyte
        {
            [Symbol("smode16")]
            smode16 = 0,

            [Symbol("smode32")]
            smode32= 1,

            [Symbol("smode64")]
            smode64 = 3
        }
    }
}