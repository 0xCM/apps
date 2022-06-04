//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessPartition
    {
        public const string TableId = "image.process.partitions";

        public MemoryAddress BaseAddress;

        public MemoryAddress EndAddress;

        public ByteSize Size;

        public ByteSize Gap;

        public Name ImageName;
    }
}