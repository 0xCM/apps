//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class Pointed
    {
        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, uint count)
            => Refs.cover(@as<T>(pSrc), count);

        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, int count)
            => Refs.cover(@as<T>(pSrc), count);

        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, long count)
            => Refs.cover(@as<T>(pSrc), count);

        /// <summary>
        /// Creates a <see cref='Span{T}'/> over a <typeparamref name='T'/> measured memory segment sourced from a pointer
        /// </summary>
        /// <param name="pSrc">A pointer to the leading cell</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> cover<T>(void* pSrc, ulong count)
            => Refs.cover(@as<T>(pSrc), count);
    }
}