//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeMapEntry
    {
        public const string TableId = "asm.codemap";

        public const byte FieldCount = 12;

        public Hex64 Id;

        public MemoryAddress MappedAddress;

        public MemoryAddress MappedRebase;

        public Label Origin;

        public Label BlockName;

        public uint BlockNumber;

        public MemoryAddress BlockAddress;

        public ByteSize BlockSize;

        public MemoryAddress EntryAddress;

        public byte EncodingSize;

        public AsmHexRef Encoded;

        public SourceText Asm;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{18,16,16,42,42,16,12,12,16,12,42,1};
    }
}