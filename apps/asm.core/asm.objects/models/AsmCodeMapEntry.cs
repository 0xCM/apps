//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeMapEntry : IComparable<AsmCodeMapEntry>
    {
        const string TableId = "asm.codemap";

        [Render(ColWidths.Seq)]
        public uint Seq;

        [Render(ColWidths.DocSeq)]
        public uint DocSeq;

        [Render(ColWidths.EncodingId)]
        public EncodingId EncodingId;

        [Render(ColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(ColWidths.OriginName)]
        public Label OriginName;

        [Render(ColWidths.InstructionId)]
        public InstructionId InstructionId;

        [Render(ColWidths.IP)]
        public MemoryAddress IP;

        [Render(ColWidths.Size)]
        public byte Size;

        [Render(ColWidths.Encoded)]
        public AsmHexRef Encoded;

        [Render(ColWidths.AsmExpr)]
        public SourceText Asm;

        [Render(ColWidths.BlockName)]
        public Label BlockName;

        [Render(ColWidths.BlockNumber)]
        public uint BlockNumber;

        [Render(ColWidths.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(ColWidths.BlockSize)]
        public ByteSize BlockSize;

        public int CompareTo(AsmCodeMapEntry src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }
    }
}