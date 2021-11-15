//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct bit
    {
		[MethodImpl(Inline), Op]
        public static ref BitPos sub(ref BitPos pos, uint bitindex)
        {
            var newIndex = pos.LinearIndex - bitindex;
            if(newIndex > 0)
			{
				pos.CellIndex = BitPosInternals.linearIndex(pos.CellWidth, bitindex);
				pos.BitOffset = BitPosInternals.offsetMod(pos.CellWidth, bitindex);
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
				pos.CellIndex = BitPosInternals.linearIndex(pos.CellWidth, bitindex);
				pos.BitOffset = BitPosInternals.offsetMod(pos.CellWidth, bitindex);
			}
            else
            {
				pos.CellIndex = 0;
				pos.BitOffset = 0;
			}

            return ref pos;
        }
    }
}