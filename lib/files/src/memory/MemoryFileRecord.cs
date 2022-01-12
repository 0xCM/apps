//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemoryFileRecord : IRecord<MemoryFileRecord>
    {
        public const string TableId = "memoryfile";

        public MemoryAddress BaseAddress;

        public ByteSize Size;

        public MemoryAddress EndAddress;

        public FS.FilePath Path;

        public Timestamp CreateTS;

        public Timestamp UpdateTS;

        public FileAttributes Attributes;
    }
}