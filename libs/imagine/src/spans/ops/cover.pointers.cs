//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class Spans
    {
        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, uint count)
            => cover(Refs.@as<T>(pSrc), count);

        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, int count)
            => cover(Refs.@as<T>(pSrc), count);

        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, long count)
            => cover(Refs.@as<T>(pSrc), count);

        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, ulong count)
            => cover(Refs.@as<T>(pSrc), count);

        /// <summary>
        /// Covers a pointer-identified T-counted buffer with a span
        /// </summary>
        /// <param name="pSrc">The memory source</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(T* pSrc, uint count)
            where T : unmanaged
                => CreateSpan(ref Refs.@ref<T>(pSrc), (int)count);

        /// <summary>
        /// Covers a pointer-identified T-counted buffer with a span
        /// </summary>
        /// <param name="pSrc">The memory source</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(T* pSrc, int count)
            where T : unmanaged
                => CreateSpan(ref Refs.@ref<T>(pSrc), (int)count);

        /// <summary>
        /// Covers a pointer-identified T-counted buffer with a span
        /// </summary>
        /// <param name="pSrc">The memory source</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(T* pSrc, long count)
            where T : unmanaged
                => CreateSpan(ref Refs.@ref<T>(pSrc), (int)count);

        /// <summary>
        /// Covers a pointer-identified T-counted buffer with a span
        /// </summary>
        /// <param name="pSrc">The memory source</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(T* pSrc, ulong count)
            where T : unmanaged
                => CreateSpan(ref Refs.@ref<T>(pSrc), (int)count);
    }
}