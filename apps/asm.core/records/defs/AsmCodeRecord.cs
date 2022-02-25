//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeRecord : IComparable<AsmCodeRecord>
    {
        public const string TableId = "asm.code";

        public const byte FieldCount = 11;

        public uint DocSeq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public InstructionId InstructionId;

        public Label OriginName;

        public MemoryAddress IP;

        public byte Size;

        public AsmHexRef Encoded;

        public SourceText Asm;

        public Label BlockName;

        public MemoryAddress BlockBase;

        public int CompareTo(AsmCodeRecord src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.DocSeq,
            ColWidths.EncodingId,
            ColWidths.OriginId,
            ColWidths.InstructionId,
            ColWidths.OriginName,
            ColWidths.IP,
            ColWidths.Size,
            ColWidths.Encoded,
            ColWidths.AsmExpr,
            ColWidths.BlockName,
            1
            };
    }
}