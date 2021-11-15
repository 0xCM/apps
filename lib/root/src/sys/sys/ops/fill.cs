//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial struct sys
    {
        /// <summary>
        /// Populates each cell of a target span with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static void fill<T>(T src, Span<T> dst)
            => proxy.fill(src,dst);

        /// <summary>
        /// Overwrites a reference-identified memory segment with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The leading target cell</param>
        /// <param name="length">The byte-measured segment length</param>
        [MethodImpl(Options), Op]
        public static ref byte fill(byte src, ref byte dst, uint length)
            => ref proxy.fill(src, ref dst, length);

        /// <summary>
        /// Fills an array, in-place, with a specified value
        /// </summary>
        /// <param name="dst">The target array</param>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] fill<T>(T[] dst, T src)
            => proxy.fill(dst,src);
    }
}