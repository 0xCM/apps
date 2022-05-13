//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitfieldCell<T> cell<T>(T src, uint offset, byte width)
            where T : unmanaged
                => new BitfieldCell<T>(segment(src, offset, width));
    }
}