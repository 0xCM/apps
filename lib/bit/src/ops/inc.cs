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
    }
}