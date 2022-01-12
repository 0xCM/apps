//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial struct minicore
    {
        /// <summary>
        /// Returns a reference to the head of a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(Span<T> src)
            => ref GetReference<T>(src);

        /// <summary>
        /// Returns a reference to the location of the first element
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref T first<T>(T[] src)
            => ref seek<T>(src, 0);

        /// <summary>
        /// Returns a reference to the head of a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T first<T>(ReadOnlySpan<T> src)
            => ref GetReference<T>(src);

        /// <summary>
        /// Reads the first T-cell from a bytespan
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T first<T>(ReadOnlySpan<byte> src)
            where T : struct
                => ref @as<byte,T>(first(src));

        /// <summary>
        /// Returns a readonly reference to the first source cell
        /// </summary>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op]
        public static ref readonly char first(ReadOnlySpan<char> src)
            => ref GetReference(src);
    }
}