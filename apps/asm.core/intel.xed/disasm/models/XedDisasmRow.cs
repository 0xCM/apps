//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct XedDisasmRow : IComparable<XedDisasmRow>
    {
        public const string TableId = "xed.disasm.summary";

        public const byte FieldCount = 11;

        [Render(ColWidths.Seq)]
        public uint Seq;

        [Render(ColWidths.DocSeq)]
        public uint DocSeq;

        [Render(ColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(ColWidths.OriginName)]
        public @string OriginName;

        [Render(ColWidths.EncodingId)]
        public EncodingId EncodingId;

        [Render(ColWidths.InstructionId)]
        public InstructionId InstructionId;

        [Render(ColWidths.IP)]
        public MemoryAddress IP;

        [Render(ColWidths.Size)]
        public byte Size;

        [Render(ColWidths.Encoded)]
        public AsmHexCode Encoded;

        [Render(ColWidths.AsmExpr)]
        public AsmExpr Asm;

        [Render(1)]
        public FS.FileUri Source;

        public int CompareTo(XedDisasmRow src)
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
            1};

        public static XedDisasmRow Empty => default;
    }
}