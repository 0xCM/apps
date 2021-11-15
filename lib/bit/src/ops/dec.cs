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
    }
}