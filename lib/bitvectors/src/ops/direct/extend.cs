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
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 extend(BitVector4 src, W8 n)
            => BitVector.create(n, src.State);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 extend(BitVector8 src, W16 n)
            => BitVector.create(n, src.State);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 extend(BitVector16 src, W32 n)
            => BitVector.create(n, src.State);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 extend(BitVector32 src, W64 n)
            => BitVector.create(n, src.State);

        /// <summary>
        /// Zero extends the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="n">The target width</param>
        [MethodImpl(Inline), Op]
        public static BitVector128<N128,ulong> extend(BitVector64 src, W128 n)
            => new BitVector128<N128, ulong>(cpu.vscalar(n,src.State));
    }
}