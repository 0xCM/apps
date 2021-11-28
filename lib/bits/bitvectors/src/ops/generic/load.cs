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
        /// Creates a generic bitvector
        /// </summary>
        /// <param name="src">The source cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector<T> load<T>(T src)
            where T : unmanaged
                => new BitVector<T>(src);

        /// <summary>
        /// Creates a generic bitvector from a span of bytes
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="n">The bitvector length</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector<T> load<T>(Span<byte> src)
            where T : unmanaged
                => load(src.Take<T>());

        /// <summary>
        /// Loads an bitvector of minimal size from a source bitstring
        /// </summary>
        /// <param name="src">The bitstring source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector<T> load<T>(BitString src)
            where T : unmanaged
                => load<T>(src.ToPackedBytes());

        /// <summary>
        /// Creates a byte-generic bitvector
        /// </summary>
        [MethodImpl(Inline), Op]
        public static BitVector<byte> load(N8 n8, byte a)
            => a;

        /// <summary>
        /// Creates a byte-generic bitvector from 4 explicit bytes
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitVector<uint> load(byte x0, byte x1, byte x2, byte x3)
            => load(bits.join(x0,x1,x2,x3));
    }
}