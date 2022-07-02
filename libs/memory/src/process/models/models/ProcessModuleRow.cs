//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleRow
    {
        public const string TableId = "image.process.modules";

        public MemoryAddress BaseAddress;

        public ByteSize MemorySize;

        public string ImageName;

        public MemoryAddress EntryAddress;

        public ApiVersion Version;

        public FS.FilePath ImagePath;
    }
}