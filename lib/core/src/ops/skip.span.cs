//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, byte count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, ushort count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, uint count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, ulong count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, long count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, byte count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, ushort count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, uint count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, ulong count)
            => ref skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(Span<T> src, long count)
            => ref skip(in first(src), count);
    }
}