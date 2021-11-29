//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct LookupTables
    {
       [MethodImpl(Inline), Op]
        public static uint offset(GridDim<ushort> dim, ushort row, ushort col)
            => CellCalcs.offset(dim,row,col);

        [MethodImpl(Inline), Op]
        public static uint offset(GridDim<ushort> dim, LookupKey key)
            => CellCalcs.offset(dim,key.Row(), key.Col());
    }
}