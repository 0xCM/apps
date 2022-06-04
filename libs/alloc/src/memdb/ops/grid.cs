//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public static Grid<T> grid<T>(Dim2<uint> shape)
            => new Grid<T>(new RowGrid<T>(shape), new ColGrid<T>(shape));
    }
}