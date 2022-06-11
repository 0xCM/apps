//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexDataRow
    {
        const string TableId = "hex.dat";

        public MemoryAddress Address;

        public BinaryCode Data;

        public static HexDataRow Empty => default;
    }

    [StructLayout(LayoutKind.Sequential,Pack=16)]
    public struct HexDat<W,T>
        where T : unmanaged, IStorageBlock
        where W : unmanaged, ITypeWidth
    {
        public readonly MemoryAddress Address;

        public readonly T Data;

        public HexDat(MemoryAddress address, T data)
        {
            Address = address;
            Data = data;
        }
    }

    public class HexDat
    {
        public static HexDat<W8,S> row<S>(W8 w, MemoryAddress address, S src)
            where S : unmanaged, IStorageBlock
                => new HexDat<W8,S>(address, src);

    }
}