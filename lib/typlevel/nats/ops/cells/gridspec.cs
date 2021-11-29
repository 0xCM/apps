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

    partial struct CellCalcs
    {
        /// <summary>
        /// Defines a grid specification predicated on specified row count, col count and bit width
        /// </summary>
        /// <param name="rows">The number of rows in the grid</param>
        /// <param name="cols">The number of columns in the grid</param>
        /// <param name="segwidth">The width of a grid cell</param>
        [MethodImpl(Inline), Op]
        public static GridSpec gridspec(ushort rows, ushort cols, ushort segwidth)
        {
            var bytes = (uint)gridsize(rows, cols);
            var bits = bytes*8;
            var segs = gridcells(rows, cols, segwidth);
            return new GridSpec(rows, cols, segwidth, bytes, bits, segs);
        }

        /// <summary>
        /// Defines a grid specification predicated on specified row count, col count and bit width of a parametric type
        /// </summary>
        /// <param name="rows">The number of rows in the grid</param>
        /// <param name="cols">The number of columns in the grid</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridSpec gridspec<T>(ushort rows, ushort cols)
            where T : unmanaged
                => gridspec(rows, cols, width<T>(w16));

        [MethodImpl(Inline)]
        public static GridSpec gridspec<M,N,T>(M m = default, N n = default, T zero = default)
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
            where T : unmanaged
                => gridspec<T>((ushort)nat64u<M>(), (ushort)nat64u<N>());
    }
}