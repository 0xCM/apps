//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct XedDisasmSummary : IComparable<XedDisasmSummary>
    {
        public const string TableId = "asm.encoding";

        public const byte FieldCount = 11;

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public @string OriginName;

        public EncodingId EncodingId;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public byte Size;

        public AsmHexCode Encoded;

        public AsmExpr Asm;

        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public int CompareTo(XedDisasmSummary src)
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

        public static XedDisasmSummary Empty => default;
    }
}