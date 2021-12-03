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

    partial class gbits
    {
        /// <summary>
        /// Queries/manipulates a source cell that covers a position-identified bit
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="pos">The sequence-relative position of the target bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitCell, Closures(Closure)]
        public static ref T bitcell<T>(Span<T> src, BitPos<T> pos)
            where T : unmanaged
                => ref seek(src, pos.CellIndex);

        /// <summary>
        /// Queries/manipulates a source cell that covers a position-identified bit
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="pos">The sequence-relative position of the target bit</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), BitCell, Closures(Closure)]
        public static ref readonly T bitcell<T>(ReadOnlySpan<T> src, BitPos<T> pos)
            where T : unmanaged
                => ref skip(src, pos.CellIndex);

        /// <summary>
        /// Reads/manipulates a cell identified by a linear bit position
        /// </summary>
        /// <param name="bitpos">The linear bit position</param>
        /// <param name="src">A reference to grid storage</param>
        /// <typeparam name="T">The storage segment type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bitcell<T>(ref T src, uint bitpos)
            where T : unmanaged
                => ref seek(src, bitpos / width<T>());
    }
}