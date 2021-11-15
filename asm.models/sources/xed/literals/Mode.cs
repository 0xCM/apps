//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-cpuid-bit-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum Mode : sbyte
        {
            [Symbol("mode16")]
            Mode16 = 0,

            [Symbol("mode32")]
            Mode32 = 1,

            [Symbol("mode64")]
            Mode64 = 2,

            [Symbol("not64")]
            Not64 = Mode16 | Mode32,
        }
    }
}