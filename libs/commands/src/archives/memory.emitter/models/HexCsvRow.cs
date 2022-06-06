//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct HexCsvRow
    {
        const string TableId = "hex.csv";

        public const byte BPL = 64;

        public MemoryAddress Address;

        public BinaryCode Data;
    }
}