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
        public static bool eq(in BitPos a, in BitPos b)
			=> a.CellIndex == b.CellIndex
            && a.BitOffset == b.BitOffset
			&& a.CellWidth == b.CellWidth;

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static bool eq<T>(in BitPos<T> a, in BitPos<T> b)
            where T : unmanaged
                => a.CellIndex == b.CellIndex
                && a.BitOffset == b.BitOffset;
    }
}
