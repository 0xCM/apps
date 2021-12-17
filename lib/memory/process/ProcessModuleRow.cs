//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleRow : IRecord<ProcessModuleRow>
    {
        public const string TableId = "image.process.modules";

        public MemoryAddress BaseAddress;

        public ByteSize MemorySize;

        public Name ImageName;

        public MemoryAddress EntryAddress;

        public VersionSpec Version;

        public FS.FilePath ImagePath;
    }
}