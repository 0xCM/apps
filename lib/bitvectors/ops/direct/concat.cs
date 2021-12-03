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
        /// Creates an 8-bit vector by concatenating a pair of 4-bit vectors
        /// </summary>
        /// <param name="lo">The lower bits of the new vector</param>
        /// <param name="hi">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 concat(BitVector4 lo, BitVector4 hi)
            => create(n8,hi.Data << 4 | lo.Data);

        /// <summary>
        /// Creates a 16-bit vector by concatenating 4 4-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that from the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 concat(BitVector4 x0, BitVector4 x1, BitVector4 x2, BitVector4 x3)
            => concat(concat(x0,x1), concat(x2,x3));

        /// <summary>
        /// Creates an 16-bit vector by concatenating a pair of 8-bit vectors
        /// </summary>
        /// <param name="lo">The lower bits of the new vector</param>
        /// <param name="hi">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 concat(BitVector8 lo, BitVector8 hi)
            => create(n16, lo.Data, hi.Data);

        /// <summary>
        /// Creates a 32-bit vector by concatenating a pair of 16-bit vectors
        /// </summary>
        /// <param name="lo">The lower bits of the new vector</param>
        /// <param name="hi">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 concat(BitVector16 lo, BitVector16 hi)
            => create(n32, lo.Data, hi.Data);

        /// <summary>
        /// Creates a 32-bit vector by concatenating 4 8-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that forms the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 concat(BitVector8 x0, BitVector8 x1, BitVector8 x2,  BitVector8 x3)
            => create(n32, x0.Data, x1.Data, x2.Data, x3.Data);

        /// <summary>
        /// Creates a 64-bit vector by concatenating 8 8-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that forms the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The fourth segment</param>
        /// <param name="x4">The fifth segment</param>
        /// <param name="x5">The sixth segment</param>
        /// <param name="x6">The pentultimate segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 concat(BitVector8 x0, BitVector8 x1, BitVector8 x2,  BitVector8 x3,
            BitVector8 x4, BitVector8 x5, BitVector8 x6,  BitVector8 x7)
                => concat(concat(x0,x1,x2,x3), concat(x4,x5,x6,x7));

        /// <summary>
        /// Creates a 64-bit vector by concatenating 4 16-bit vectors
        /// </summary>
        /// <param name="x0">The first segment that forms the least significant bits of the new vector</param>
        /// <param name="x1">The second segment</param>
        /// <param name="x2">The third segment</param>
        /// <param name="x3">The last segment that forms the most significant bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 concat(BitVector16 x0, BitVector16 x1, BitVector16 x2, BitVector16 x3)
            => create(n64, x0.Data, x1.Data, x2.Data, x3.Data);

        /// <summary>
        /// Creates a 64-bit vector by concatenating a pair of 32-bit vectors
        /// </summary>
        /// <param name="lo">The lower bits of the new vector</param>
        /// <param name="hi">The upper bits of the new vector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 concat(BitVector32 lo, BitVector32 hi)
            => create(n64, lo.Data, hi.Data);
    }
}