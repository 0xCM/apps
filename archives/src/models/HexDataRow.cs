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

        [MethodImpl(Inline)]
        public HexDataRow(MemoryAddress address, BinaryCode data)
        {
            Address = address;
            Data = data;
        }

        public static HexDataRow Empty => default;
    }
}