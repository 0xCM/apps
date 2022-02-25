//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmEncodingRow : IAsmEncodingRecord, IComparable<AsmEncodingRow>
    {
        public const string TableId = "asm.encoding";

        public const byte FieldCount = 11;

        public uint Seq;

        public uint DocSeq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public InstructionId InstructionId;

        public @string OriginName;

        public MemoryAddress IP;

        public AsmHexCode Encoded;

        public byte Size;

        public AsmExpr Asm;

        public FS.FileUri Source;

        EncodingId IAsmEncodingRecord.EncodingId
            => EncodingId;

        Hex32 IOriginated.OriginId
            => OriginId;

        uint ISequential.Seq
            => Seq;

        AsmExpr IAsmEncodingRecord.Asm
            => Asm;

        AsmHexCode IAsmEncodingRecord.Encoded
            => Encoded;

        MemoryAddress IAsmEncodingRecord.IP
            => IP;

        public int CompareTo(AsmEncodingRow src)
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
            ColWidths.InstructionId,
            ColWidths.OriginName,
            ColWidths.IP,
            ColWidths.Encoded,
            ColWidths.Size,
            84,
            1};

        public static AsmEncodingRow Empty => default;
    }
}