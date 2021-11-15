//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Wraps a bitspan over a span of extant bits
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<bit> src)
            => BitSpans.load(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<byte> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<ushort> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<uint> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this ReadOnlySpan<ulong> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<byte> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<ushort> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<uint> src)
            => BitSpans.create(src);

        /// <summary>
        /// Loads a bitspan from a packed span of scalars
        /// </summary>
        /// <param name="src">The packed source</param>
        [MethodImpl(Inline), Op]
        public static BitSpan ToBitSpan(this Span<ulong> src)
            => BitSpans.create(src);

        /// <summary>
        /// Converts an 128-bit intrinsic vector representation to a bitspan
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        public static BitSpan ToBitSpan<T>(this Vector128<T> src, uint? maxbits = null)
            where T : unmanaged
                => BitSpans.load(src, maxbits);

        /// <summary>
        /// Converts an 128-bit intrinsic vector representation to a bitspan
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
        public static BitSpan ToBitSpan<T>(this Vector256<T> src, uint? maxbits = null)
            where T : unmanaged
                => BitSpans.load(src, maxbits);

        /// <summary>
        /// Converts an enumeration value to a bitspan
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The enumeration type</typeparam>
        public static BitSpan ToBitSpan<T>(this T src, uint? maxbits = null)
            where T : unmanaged, Enum
                => BitSpans.load(src, maxbits);
   }
}