//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVector
    {
        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector4 x)
            => (uint)x.Width - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector8 x)
            => (uint)x.Width - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector16 x)
            => (uint)x.Width - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector64 x)
            => (uint)x.Width - nlz(x);
    }
}