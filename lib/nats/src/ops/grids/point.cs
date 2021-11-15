//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Grids
    {
        [MethodImpl(Inline), Op]
        public static GridPoint point(uint row, uint col)
            => new GridPoint(row, col);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridPoint<T> point<T>(T row, T col)
            where T : unmanaged
                => new GridPoint<T>(row, col);
    }
}