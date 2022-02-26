//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeRow : IComparable<AsmCodeRow>
    {
        public const string TableId = "asm.code";

        public const byte FieldCount = 12;

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public Label OriginName;

        public EncodingId EncodingId;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public byte Size;

        public AsmHexRef Encoded;

        public SourceText Asm;

        public Label BlockName;

        public MemoryAddress BlockBase;

        public int CompareTo(AsmCodeRow src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.Seq,
            ColWidths.DocSeq,
            ColWidths.OriginId,
            ColWidths.OriginName,
            ColWidths.EncodingId,
            ColWidths.InstructionId,
            ColWidths.IP,
            ColWidths.Size,
            ColWidths.Encoded,
            ColWidths.AsmExpr,
            ColWidths.BlockName,
            1
            };
    }
}