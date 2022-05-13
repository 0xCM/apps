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
        public static T segment<T>(T src, uint index, Index<uint> offsets, Index<byte> widths)
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), (byte)offsets[index], (byte)(offsets[index] + widths[index])));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T segment<T>(T src, uint offset, byte width)
            where T : unmanaged
                => generic<T>(bits.extract(bw64(src), (byte)offset, (byte)(offset + width)));
    }
}