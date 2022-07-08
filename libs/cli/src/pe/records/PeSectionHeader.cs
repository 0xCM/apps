//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct PeSectionHeader
    {
        public const string TableId = "section.headers";

        public FS.FileName File;

        public string SectionName;

        public Address32 CodeBase;

        public Address32 GptRva;

        public ByteSize GptSize;

        public SectionCharacteristics SectionFlags;

        public Address32 RawDataAddress;

        public ByteSize RawDataSize;

        public Address32 EntryPoint;
    }
}