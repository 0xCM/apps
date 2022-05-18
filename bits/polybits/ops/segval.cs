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
        public static T segval<T>(T src, uint offset, byte width)
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), (byte)offset, (byte)(offset + width)));

        [MethodImpl(Inline)]
        public static T segval<F,S,T>(S src, F field, BfDataset<F> bf)
            where F : unmanaged, Enum
            where T : unmanaged
            where S : unmanaged
                => @as<ulong,T>(segval(bw64(src), bf.Offset(field), bf.Width(field)));
    }
}