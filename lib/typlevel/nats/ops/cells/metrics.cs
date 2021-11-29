//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CellCalcs
    {
        /// <summary>
        /// Calculates a grid layout from a specification
        /// </summary>
        /// <param name="spec">The grid specification that characterizes the layout</param>
        [MethodImpl(Inline), Op]
        public static GridMetrics metrics(in GridSpec spec)
            => new GridMetrics(spec);

        /// <summary>
        /// Defines a grid map predicated row count, col count and storage segment bit width width
        /// </summary>
        /// <param name="rows">The number of rows in the grid</param>
        /// <param name="cols">The number of columns in the grid</param>
        /// <param name="segwidth">The width of a grid cell</param>
        [MethodImpl(Inline), Op]
        public static GridMetrics metrics(ushort rows, ushort cols, ushort segwidth)
             => metrics(CellCalcs.gridspec(rows, cols, segwidth));

        /// <summary>
        /// Defines a grid map predicated row count, col count and the bit width of parametric type
        /// </summary>
        /// <param name="rows">The number of rows in the grid</param>
        /// <param name="cols">The number of columns in the grid</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridMetrics metrics<T>(ushort rows, ushort cols)
            where T : unmanaged
                => metrics(CellCalcs.gridspec<T>(rows,cols));

        /// <summary>
        /// Calculates memory block statistics for specified function and type parameters
        /// </summary>
        /// <param name="bc">The block count</param>
        /// <param name="bw">The block width representative</param>
        /// <param name="t">The block cell type representative</param>
        /// <typeparam name="N">The type that dermines block width</typeparam>
        /// <typeparam name="T">The type that determines cell width</typeparam>
        [MethodImpl(Inline)]
        public static BlockedGridStats<W,T> stats<W,T>(int bc, W bw = default, T t = default)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => new BlockedGridStats<W,T>(bc);

        /// <summary>
        /// Defines a grid map predicated on type parameters
        /// </summary>
        /// <param name="RowCount">The number of rows in the grid</param>
        /// <param name="ColCount">The number of columns in the grid</param>
        /// <param name="CellWidth">The width of a grid cell</param>
        /// <typeparam name="T">The storage segment type</typeparam>
        [MethodImpl(Inline)]
        public static GridMetrics metrics<M,N,T>(M m = default, N n = default, T zero = default)
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
            where T : unmanaged
                => metrics(CellCalcs.gridspec(m,n, zero));
    }
}