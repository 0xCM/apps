//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleRow : IComparable<ProcessModuleRow>
    {
        const string TableId = "process.modules";

        [Render(16)]
        public MemoryAddress MinAddress;

        [Render(16)]
        public MemoryAddress EntryAddress;

        [Render(16)]
        public MemoryAddress MaxAddress;

        [Render(16)]
        public ByteSize MemorySize;

        [Render(64)]
        public string ImageName;

        [Render(12)]
        public ApiVersion Version;

        [Render(1)]
        public FS.FileUri ImagePath;

        [MethodImpl(Inline)]
        public int CompareTo(ProcessModuleRow src)
        {
            var result = MinAddress.CompareTo(src.MinAddress);
            if(result == 0)
                result = EntryAddress.CompareTo(src.EntryAddress);
            return result;
        }
    }
}