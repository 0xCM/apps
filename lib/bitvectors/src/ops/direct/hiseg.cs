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
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector4 hiseg(BitVector4 x, byte n)
            => bitseg(x, (byte)((uint)x.Width - n), (byte)((uint)x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector8 hiseg(BitVector8 x, byte n)
            => bitseg(x, (byte)((uint)x.Width - n), (byte)((uint)x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector16 hiseg(BitVector16 x, byte n)
            => bitseg(x, (byte)((uint)x.Width - n), (byte)((uint)x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector32 hiseg(BitVector32 x, byte n)
            => BitVector.bitseg(x.State, (byte)((uint)x.Width - n), (byte)((uint)x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector64 hiseg(BitVector64 x, byte n)
            => bitseg(x, (byte)((uint)x.Width - n), (byte)((uint)x.Width - 1));
    }
}