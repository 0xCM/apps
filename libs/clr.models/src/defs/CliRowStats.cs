//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliRowStats
    {
        const string TableId = "cli.stats";

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public byte TableIndex;

        [Render(32)]
        public StringAddress TableName;

        [Render(48)]
        public StringAddress Component;

        [Render(12)]
        public uint RowCount;

        [Render(12)]
        public byte RowSize;

        [Render(12)]
        public ByteSize TableSize;
    }
}