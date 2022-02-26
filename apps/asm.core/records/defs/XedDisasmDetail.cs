//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableName)]
    public struct XedDisasmDetail : IComparable<XedDisasmDetail>
    {
        public const string TableName = "xed.disasm.detail";

        public const byte FieldCount = 21;

        public uint Seq;

        public uint DocSeq;

        public EncodingId EncodingId;

        public Hex32 OriginId;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public AsmHexCode Encoded;

        public Hex8 OpCode;

        public byte PSZ;

        public RexPrefix Rex;

        public VexPrefix Vex;

        public EvexPrefix Evex;

        public ModRm ModRm;

        public Sib Sib;

        public Disp Disp;

        public SizeOverride SZOV;

        public AsmExpr Asm;

        public IFormType IForm;

        public @string SourceName;

        public EncodingOffsets Offsets;

        public InstOperands Operands;

        public DocRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq);
        }

        public int CompareTo(XedDisasmDetail src)
        {
            var result = SourceName.CompareTo(src.SourceName);
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
            ColWidths.IP,
            ColWidths.Encoded,
            8,5,5,12,12,5,5,12,5,54,54,42,48,1};

        public static XedDisasmDetail Empty => default;
    }
}