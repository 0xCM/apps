//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using Windows;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessMemoryRegion : IComparableRecord<ProcessMemoryRegion>
    {
        public const string TableId = "image.memory.regions";

        public const byte FieldCount = 9;

        public uint Index;

        public Name Identity;

        public MemoryAddress StartAddress;

        public MemoryAddress EndAddress;

        public ByteSize Size;

        public MemType Type;

        public PageProtection Protection;

        public MemState State;

        public TextBlock FullIdentity;

        public MemoryRange Range
            => (StartAddress, EndAddress);

        public int CompareTo(ProcessMemoryRegion src)
            => StartAddress.CompareTo(src.StartAddress);

        public string Describe()
            => string.Format("[{0},{1}]({2})", StartAddress, StartAddress + Size, (ByteSize)Size);

        public override string ToString()
            => Describe();
    }
}