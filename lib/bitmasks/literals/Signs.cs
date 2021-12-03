//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [10000000]
        /// </summary>
        [BitMask ("10000000")]
        public const byte SignMask8 = Pow2.T07;

        /// <summary>
        /// [10000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000")]
        public const ushort SignMask16 = Pow2.T15;

        /// <summary>
        /// [10000000 00000000 00000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000 00000000 00000000")]
        public const uint SignMask32 = Pow2.T31;

        /// <summary>
        /// [10000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000 00000000 00000000 00000000 00000000 00000000 00000000")]
        public const ulong SignMask64 = Pow2.T63;
    }
}