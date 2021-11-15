//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemoryFileInfo : IRecord<MemoryFileInfo>
    {
        public const string TableId = "memoryfile-info";

        public MemoryAddress BaseAddress;

        public ByteSize Size;

        public MemoryAddress EndAddress;

        public FS.FilePath Path;

        public Timestamp CreateTS;

        public Timestamp UpdateTS;

        public FileAttributes Attributes;
    }
}