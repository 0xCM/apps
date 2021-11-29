//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct LookupTables
    {
        [Op, Closures(Closure)]
        public static LookupTable<T> table<T>(ushort rows, ushort cols)
            => new LookupTable<T>((rows,cols), alloc<T>(rows*cols));

        [Op, Closures(Closure)]
        public static LookupTable<T> table<T>(ushort rows, ushort cols, T[] cells)
        {
            Require.invariant(cells.Length == rows*cols);
            return new LookupTable<T>((rows,cols), cells);
        }
    }
}