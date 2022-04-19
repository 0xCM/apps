//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XSb
    {
        /// <summary>
        /// Converts 64-bit blocks to 32-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> Reblock<T>(this in SpanBlock32<T> src, W16 n)
             where T : unmanaged
                => new SpanBlock16<T>(src.Storage);

        /// <summary>
        /// Converts 64-bit blocks to 32-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock32<T> Reblock<T>(this in SpanBlock64<T> src, W32 n)
             where T : unmanaged
                => new SpanBlock32<T>(src.Storage);

        /// <summary>
        /// Converts 128-bit blocks to 16-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> Reblock<T>(this in SpanBlock128<T> src, W16 n)
             where T : unmanaged
                => new SpanBlock16<T>(src.Storage);

        /// <summary>
        /// Converts 128-bit blocks to 32-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock32<T> Reblock<T>(this in SpanBlock128<T> src, W32 n)
             where T : unmanaged
                => new SpanBlock32<T>(src.Storage);

        /// <summary>
        /// Converts 128-bit blocks to 64-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock64<T> Reblock<T>(this in SpanBlock128<T> src, W64 n)
             where T : unmanaged
                => new SpanBlock64<T>(src.Storage);

        /// <summary>
        /// Converts 256-bit blocks to 16-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> Reblock<T>(this in SpanBlock256<T> src, W16 n)
             where T : unmanaged
                => new SpanBlock16<T>(src.Storage);

        /// <summary>
        /// Converts 256-bit blocks to 32-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock32<T> Reblock<T>(this in SpanBlock256<T> src, W32 n)
             where T : unmanaged
                => new SpanBlock32<T>(src.Storage);

        /// <summary>
        /// Converts 256-bit blocks to 64-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock64<T> Reblock<T>(this in SpanBlock256<T> src, W64 n)
             where T : unmanaged
                => new SpanBlock64<T>(src.Storage);

        /// <summary>
        /// Converts 256-bit blocks to 64-bit blocks without allocation
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="n">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock128<T> Reblock<T>(this in SpanBlock256<T> src, W128 n)
             where T : unmanaged
                => new SpanBlock128<T>(src.Storage);
    }
}