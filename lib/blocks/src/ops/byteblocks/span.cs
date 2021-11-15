//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class ByteBlocks
    {
        /// <summary>
        /// Fills a span with data from a memory block
        /// </summary>
        /// <param name="src">The stack storage source</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> span<T>(ref ByteBlock8 src)
            where T : unmanaged
                => recover<T>(cover(u8(src), ByteBlock8.Size));

        /// <summary>
        /// Fills a span with data from a memory block
        /// </summary>
        /// <param name="src">The stack storage source</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(ref ByteBlock16 src)
            where T : unmanaged
                => recover<T>(cover(u8(src), ByteBlock16.Size));

        /// <summary>
        /// Fills a span with data from a memory block
        /// </summary>
        /// <param name="src">The stack storage source</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> span<T>(ref ByteBlock32 src)
            where T : unmanaged
                => recover<T>(cover(u8(src), ByteBlock32.Size));

        /// <summary>
        /// Fills a span with data from a memory block
        /// </summary>
        /// <param name="src">The stack storage source</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Span<T> span<T>(ref ByteBlock64 src)
            where T : unmanaged
                => recover<T>(cover(u8(src), ByteBlock64.Size));
    }
}