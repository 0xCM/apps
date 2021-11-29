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
        public static uint lineraize(GridDim dim, GridPoint point)
            => point.Row*dim.N+ point.Col;
    }
}