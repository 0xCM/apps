//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public partial class TypeNats
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static sbyte nat8i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (sbyte)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static byte nat8u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (byte)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static short nat16i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (short)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static ushort nat16u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (ushort)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static int nat32i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (int)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static uint nat32u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (uint)value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static ulong nat64u<N>(N n = default)
            where N : unmanaged, ITypeNat
                => value(n);

        /// <summary>
        /// Returns the numeric value represented by a natural type
        /// </summary>
        /// <param name="n">The natural type representative</param>
        /// <typeparam name="K">A natural type</typeparam>
        [MethodImpl(Inline)]
        public static long nat64i<N>(N n = default)
            where N : unmanaged, ITypeNat
                => (long)value(n);

        [MethodImpl(Inline)]
        public static Next<K> next<K>(K k = default)
            where K : unmanaged, ITypeNat
                => default;

        [MethodImpl(Inline)]
        public static NatSpan<N,T> span<N,T>(T[] src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => NatSpans.load(src,n);

        [MethodImpl(Inline)]
        public static NatSpan<N,T> span<N,T>(Span<T> src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => NatSpans.load(src,n);

        /// <summary>
        /// Constructs a natural representative
        /// </summary>
        /// <typeparam name="K">The representative type</typeparam>
        [MethodImpl(Inline)]
        public static K natrep<K>()
            where K : unmanaged, ITypeNat
                => default;

        /// <summary>
        /// Constructs the natural type corresponding to an integral value
        /// </summary>
        /// <param name="digits">The source digits</param>
        [MethodImpl(Inline)]
        public static INatSeq reflect(ulong value)
            => seq(digits(value));

        [MethodImpl(Inline)]
        internal static int bitsize<T>()
            => Unsafe.SizeOf<T>()*8;
    }
}