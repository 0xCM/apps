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
		[MethodImpl(Inline)]
        public static ref BitPos add(ref BitPos pos, uint bitindex)
        {
            var newindex = pos.LinearIndex + bitindex;
            pos.CellIndex = BitPosInternals.linearIndex(pos.CellWidth,newindex);
            pos.BitOffset = BitPosInternals.offsetMod(pos.CellWidth, newindex);
            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> add<T>(ref BitPos<T> pos, uint bitindex)
            where T : unmanaged
        {
            var newindex = pos.LinearIndex + bitindex;
            pos.CellIndex = BitPosInternals.linearIndex(pos.CellWidth,newindex);
            pos.BitOffset = BitPosInternals.offsetMod(pos.CellWidth, newindex);
            return ref pos;
        }
   }
}