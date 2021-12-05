//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    readonly struct BitPosCalcs
    {
        const NumericKind Closure = UnsignedInts;

		/// <summary>
		/// Computes the order-invariant absolute distance between two positions
		/// </summary>
		/// <param name="a">The left position</param>
		/// <param name="b">The right position</param>
		[MethodImpl(Inline), Op]
		public static uint delta(BitPos a, BitPos b)
			=> (uint)(a.LinearIndex > b.LinearIndex ? a.LinearIndex - b.LinearIndex : b.LinearIndex - a.LinearIndex);


		[MethodImpl(Inline), Op]
        public static ref BitPos add(ref BitPos pos, uint bitindex)
        {
            var newindex = pos.LinearIndex + bitindex;
            pos.CellIndex = linearIndex(pos.CellWidth,newindex);
            pos.BitOffset = offsetMod(pos.CellWidth, newindex);
            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> add<T>(ref BitPos<T> pos, uint bitindex)
            where T : unmanaged
        {
            var newindex = pos.LinearIndex + bitindex;
            pos.CellIndex = linearIndex(pos.CellWidth,newindex);
            pos.BitOffset = offsetMod(pos.CellWidth, newindex);
            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
		public static uint count<T>(in BitPos<T> src, in BitPos<T> dst)
            where T : unmanaged
			    => (uint)core.abs((long)src.LinearIndex - (long)dst.LinearIndex) + 1;


		[MethodImpl(Inline), Op]
        public static ref BitPos inc(ref BitPos pos)
        {
            if(pos.BitOffset < pos.CellWidth - 1)
                pos.BitOffset++;
            else
            {
                pos.CellIndex++;
                pos.BitOffset = 0;
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> inc<T>(ref BitPos<T> pos)
            where T : unmanaged
        {
            if(pos.BitOffset < pos.CellWidth - 1)
                pos.BitOffset++;
            else
            {
                pos.CellIndex++;
                pos.BitOffset = 0;
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op]
        public static ref BitPos dec(ref BitPos pos)
        {
            if(pos.BitOffset > 0)
                --pos.BitOffset;
            else
            {
                if(pos.CellIndex != 0)
                {
                    pos.BitOffset = pos.CellWidth - 1;
                    --pos.CellIndex;
                }
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> dec<T>(ref BitPos<T> pos)
            where T : unmanaged
        {
            if(pos.BitOffset > 0)
                --pos.BitOffset;
            else
            {
                if(pos.CellIndex != 0)
                {
                    pos.BitOffset = pos.CellWidth - 1;
                    --pos.CellIndex;
                }
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op]
        public static ref BitPos sub(ref BitPos pos, uint bitindex)
        {
            var newIndex = pos.LinearIndex - bitindex;
            if(newIndex > 0)
			{
				pos.CellIndex = BitPosCalcs.linearIndex(pos.CellWidth, bitindex);
				pos.BitOffset = BitPosCalcs.offsetMod(pos.CellWidth, bitindex);
			}
            else
            {
				pos.CellIndex = 0;
				pos.BitOffset = 0;
			}

            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> sub<T>(ref BitPos<T> pos, uint bitindex)
            where T : unmanaged
        {
            var newIndex = pos.LinearIndex - bitindex;
            if(newIndex > 0)
			{
				pos.CellIndex = BitPosCalcs.linearIndex(pos.CellWidth, bitindex);
				pos.BitOffset = BitPosCalcs.offsetMod(pos.CellWidth, bitindex);
			}
            else
            {
				pos.CellIndex = 0;
				pos.BitOffset = 0;
			}

            return ref pos;
        }
		[MethodImpl(Inline), Op]
        public static bool eq(in BitPos a, in BitPos b)
			=> a.CellIndex == b.CellIndex
            && a.BitOffset == b.BitOffset
			&& a.CellWidth == b.CellWidth;

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static bool eq<T>(in BitPos<T> a, in BitPos<T> b)
            where T : unmanaged
                => a.CellIndex == b.CellIndex
                && a.BitOffset == b.BitOffset;

        /// <summary>
        /// Computes the cell index of a linear bit index
        /// </summary>
        /// <param name="w">The width of a storage cell</param>
        /// <param name="index">The linear bit index</param>
		[MethodImpl(Inline), Op]
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
			=> (byte)(index % w);
    }
}