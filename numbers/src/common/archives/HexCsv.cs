//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexCsv
    {
        public const string TableId = "hex.csv";

        public const byte RowDataSize = 64;

        public MemoryAddress Address;

        public BinaryCode Data;
    }

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexDataRow
    {
        public const string TableId = "hex.dat";

        public MemoryAddress Address;

        public BinaryCode Data;

        public static HexDataRow Empty
        {
            [MethodImpl(Inline)]
            get
            {
                var empty = new HexDataRow();
                empty.Data = BinaryCode.Empty;
                return empty;
            }
        }
    }

}