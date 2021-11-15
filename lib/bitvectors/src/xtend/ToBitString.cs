//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XBv
    {
        /// <summary>
        /// Converts the vector to a bitstring
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<N,T>(this BitVector128<N,T> src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitStrings.load(src.State, src.Width);

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<N,T>(this BitVector<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVector.bitstring(x);

        /// <summary>
        /// Converts the vector content to a bitring representation
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<N,T>(this BitVector<N,T> x, byte[] storage)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVector.bitstring(x,storage);

        /// <summary>
        /// Extracts the represented data as a bitstring
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitVector<T> src)
            where T : unmanaged
                => BitVector.bitstring(src);

        /// <summary>
        /// Extracts the represented data as a bitstring truncated to a specified width
        /// </summary>
        [MethodImpl(Inline)]
        public static BitString ToBitString<T>(this BitVector<T> src, int width)
            where T : unmanaged
                => BitVector.bitstring(src,width);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector4 src)
            => BitVector.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector8 src)
            => BitVector.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector16 src)
            => BitVector.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector24 src)
             => BitVector.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector32 src)
             => BitVector.bitstring(src);

        /// <summary>
        /// Creates the vector's bitstring representation
        /// </summary>
        /// <param name="src">The source bitvector</param>
        [MethodImpl(Inline)]
        public static BitString ToBitString(this BitVector64 x)
            => BitVector.bitstring(x);
    }
}