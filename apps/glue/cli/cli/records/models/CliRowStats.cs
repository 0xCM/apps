//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliRowStats : IRecord<CliRowStats>
    {
        const string TableId = "cli.stats";

        public uint Sequence;

        public StringAddress Component;

        public StringAddress TableName;

        public Hex8 TableIndex;

        public uint RowCount;

        public byte RowSize;

        public ByteSize TableSize;
    }
}