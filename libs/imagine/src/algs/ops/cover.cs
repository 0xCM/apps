//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class Algs
    {
        /// <summary>
        /// Covers a reference-identified T-counted buffer with a span
        /// </summary>
        /// <param name="src">A reference to the leading cell</param>
        /// <param name="count">The number of T-cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cover<T>(in T src, int count)
            => CreateSpan(ref edit(src), count);

        /// <summary>
        /// Covers a reference-identified T-counted buffer with a span
        /// </summary>
        /// <param name="src">A reference to the leading cell</param>
        /// <param name="count">The number of T-cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cover<T>(in T src, uint count)
            => CreateSpan(ref edit(src), (int)count);

        /// <summary>
        /// Covers a reference-identified T-counted buffer with a span
        /// </summary>
        /// <param name="src">A reference to the leading cell</param>
        /// <param name="count">The number of T-cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cover<T>(in T src, long count)
            => CreateSpan(ref edit(src), (int)count);

        /// <summary>
        /// Covers a reference-identified T-counted buffer with a span
        /// </summary>
        /// <param name="src">A reference to the leading cell</param>
        /// <param name="count">The number of T-cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cover<T>(in T src, ulong count)
            => CreateSpan(ref edit(src), (int)count);
    }
}