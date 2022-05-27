//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessSegment : IComparableRecord<ProcessSegment>
    {
        const string TableId = "process.segments";

        [Render(16)]
        public uint Index;

        [Render(12)]
        public Address16 Selector;

        [Render(12)]
        public Address32 Base;

        [Render(8)]
        public ByteSize Size;

        [Render(12)]
        public uint PageCount;

        [Render(12)]
        public MemoryRange Range;

        [Render(12)]
        public MemType Type;

        [Render(12)]
        public PageProtection Protection;

        [Render(1)]
        public utf8 Label;

        public int CompareTo(ProcessSegment src)
            => Range.Min.CompareTo(src.Range.Max);
    }
}