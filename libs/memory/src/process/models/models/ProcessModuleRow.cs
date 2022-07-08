//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleRow : IComparable<ProcessModuleRow>
    {
        const string TableId = "image.process.modules";

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
        public MemoryAddress EntryAddress;

        [Render(16)]
        public ByteSize MemorySize;

        [Render(48)]
        public string ImageName;

        [Render(12)]
        public ApiVersion Version;

        [Render(1)]
        public FS.FilePath ImagePath;

        [MethodImpl(Inline)]
        public int CompareTo(ProcessModuleRow src)
        {
            var result = BaseAddress.CompareTo(src.BaseAddress);
            if(result == 0)
                result = EntryAddress.CompareTo(src.EntryAddress);
            return result;
        }
    }
}