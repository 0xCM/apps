//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeMapEntry : IComparable<AsmCodeMapEntry>
    {
        public const string TableId = "asm.codemap";

        public const byte FieldCount = 14;

        public uint Seq;

        public uint DocSeq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public Label OriginName;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public byte Size;

        public AsmHexRef Encoded;

        public SourceText Asm;

        public Label BlockName;

        public uint BlockNumber;

        public MemoryAddress BlockAddress;

        public ByteSize BlockSize;

        public int CompareTo(AsmCodeMapEntry src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.Seq,
            ColWidths.DocSeq,
            ColWidths.EncodingId,
            ColWidths.OriginId,
            ColWidths.OriginName,
            ColWidths.InstructionId,
            ColWidths.IP,
            ColWidths.Size,
            ColWidths.Encoded,
            ColWidths.AsmExpr,
            ColWidths.BlockName,
            12,
            12,
            12};
    }
}