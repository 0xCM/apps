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
        /// Constructs a bitvector formed from the n lest significant bits of the source vector
        /// </summary>
        /// <param name="n">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg, Closures(Closure)]
        public static BitVector<T> lo<T>(BitVector<T> src, byte n)
            where T : unmanaged
                => bitseg(src, 0, n -=1);

        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the current vector
        /// </summary>
        /// <param name="count">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg]
        public static BitVector4 lo(BitVector4 x, byte count)
            => bitseg(x, 0, (byte)(count - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the current vector
        /// </summary>
        /// <param name="count">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg]
        public static BitVector8 lo(BitVector8 x, byte count)
            => bitseg(x,0, count -=1);

        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the current vector
        /// </summary>
        /// <param name="count">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg]
        public static BitVector16 lo(BitVector16 src, byte count)
            => bitseg(src.State,0,count -=1);

        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the current vector
        /// </summary>
        /// <param name="count">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg]
        public static BitVector32 lo(BitVector32 src, byte count)
            => bitseg(src.State,0,count -=1);

        /// <summary>
        /// Constructs a bitvector formed from the n lest significant bits of the current vector
        /// </summary>
        /// <param name="n">The count of least significant bits</param>
        [MethodImpl(Inline), LoSeg]
        public static BitVector64 lo(BitVector64 src, byte n)
            => bitseg(src.State,0, n -=1);
    }
}