//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    readonly struct BitPosInternals
    {
        /// <summary>
        /// Computes the cell index of a linear bit index
        /// </summary>
        /// <param name="w">The width of a storage cell</param>
        /// <param name="index">The linear bit index</param>
		[MethodImpl(Inline)]
        public static uint linearIndex(uint w, uint index)
			=> index/w;

		/// <summary>
		/// Computes a linear bit index from a cell index and cell-relative offset
		/// </summary>
		/// <param name="w">The cell width</param>
		/// <param name="cellindex">The cell index</param>
		/// <param name="offset">The cell-relative offset of the bit</param>
		[MethodImpl(Inline), Op]
		public static uint linearIndex(uint w, uint cellindex, uint offset)
			=> cellindex*w + offset;

		[MethodImpl(Inline), Op]
        public static uint linearIndex(in BitPos src)
            => linearIndex(src.CellWidth, src.CellIndex, src.BitOffset);

        /// <summary>
        /// Computes the offset of a linear bit index over storage cells of specified width
        /// </summary>
        /// <param name="w">The cell width</param>
        /// <param name="index">The linear bit index</param>
		[MethodImpl(Inline), Op]
        public static byte offsetMod(uint w, uint index)
			=> ScalarCast.uint8(index % w);
    }
}