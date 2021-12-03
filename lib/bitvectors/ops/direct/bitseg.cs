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
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector4 bitseg(BitVector4 x, byte first, byte last)
            => bits.segment(x.State, first, last);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector8 bitseg(BitVector8 x, byte first, byte last)
            => bits.segment(x.State, first, last);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector16 bitseg(BitVector16 x, byte first, byte last)
            => bits.segment(x.State, first, last);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector32 bitseg(BitVector32 x, byte first, byte last)
            => bits.segment(x.State, first, last);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="first">The first bit position</param>
        /// <param name="last">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector64 bitseg(BitVector64 x, byte first, byte last)
            => bits.segment(x.State, first, last);
    }
}