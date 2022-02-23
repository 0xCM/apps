//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CoffSection
    {
        public const string TableId = "coff.sections";

        public const byte FieldCount = 11;

        public uint Seq;

        public Hex32 DocId;

        public ushort SectionNumber;

        public @string SectionName;

        public CoffSectionKind SectionKind;

        public ByteSize RawDataSize;

        public Address32 RawDataAddress;

        public uint RelocCount;

        public Address32 RelocAddress;

        public ImageSectionFlags Flags;

        public FS.FileUri Source;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,16,16,16,16,16,16,16,78,1};
    }
}