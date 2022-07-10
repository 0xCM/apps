//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryRegion : IComparable<ProcessMemoryRegion>
    {
        public const string TableId = "memory.regions";

        public const byte FieldCount = 9;

        public uint Index;

        [Render(16)]
        public string Name;

        [Render(16)]
        public MemoryAddress StartAddress;

        [Render(16)]
        public MemoryAddress EndAddress;

        [Render(16)]
        public ByteSize Size;

        [Render(12)]
        public MemType Type;

        [Render(16)]
        public PageProtection Protection;

        [Render(16)]
        public MemState State;

        [Render(1)]
        public FS.FileUri Path;

        public int CompareTo(ProcessMemoryRegion src)
            => StartAddress.CompareTo(src.StartAddress);

        public string Describe()
            => string.Format("[{0},{1}]({2})", StartAddress, StartAddress + Size, (ByteSize)Size);

        public override string ToString()
            => Describe();
    }
}