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
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC<T>(this ScalarBits<T> src)
            where T : unmanaged
                => BitVector.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC<N,T>(this ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => BitVector.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector8 src)
            => BitVector.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector16 src)
            => BitVector.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector32 src)
            => BitVector.testc(src);

        /// <summary>
        /// Returns true of all bits are enabled, false otherwise
        /// </summary>
        [MethodImpl(Inline)]
        public static bit TestC(this BitVector64 src)
            => BitVector.testc(src);
    }
}