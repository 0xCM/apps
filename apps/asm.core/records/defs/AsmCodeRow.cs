//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using W = ColWidths;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct AsmCodeRow : IComparable<AsmCodeRow>
    {
        public const string TableId = "asm.code";

        public const byte FieldCount = 12;

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint DocSeq;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.OriginName)]
        public Label OriginName;

        [Render(W.EncodingId)]
        public EncodingId EncodingId;

        [Render(W.InstructionId)]
        public InstructionId InstructionId;

        [Render(W.IP)]
        public MemoryAddress IP;

        [Render(W.Size)]
        public byte Size;

        [Render(W.Encoded)]
        public AsmHexRef Encoded;

        [Render(W.AsmExpr)]
        public SourceText Asm;

        [Render(W.BlockName)]
        public Label BlockName;

        [Render(1)]
        public MemoryAddress BlockBase;

        public int CompareTo(AsmCodeRow src)
        {
            var result = OriginName.CompareTo(src.OriginName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        // public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
        //     W.Seq,
        //     W.DocSeq,
        //     W.OriginId,
        //     W.OriginName,
        //     W.EncodingId,
        //     W.InstructionId,
        //     W.IP,
        //     W.Size,
        //     W.Encoded,
        //     W.AsmExpr,
        //     W.BlockName,
        //     1
        //     };
    }
}