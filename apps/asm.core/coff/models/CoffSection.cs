namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CoffSection
    {
        public const string TableId = "coff.sections";

        public const byte FieldCount = 9;

        public uint Seq;

        public uint DocId;

        public ushort Section;

        public @string SectionName;

        public uint RawDataSize;

        public Address32 RawDataAddress;

        public uint RelocCount;

        public Address32 RelocAddress;

        public ImageSectionFlags Flags;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,16,16,16,16,16,1};
    }
}