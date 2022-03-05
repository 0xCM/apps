//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableName)]
    public struct AsmDisasmDetail : IComparable<AsmDisasmDetail>
    {
        public const string TableName = "xed.disasm.detail";

        public const byte FieldCount = 25;

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public @string OriginName;

        public EncodingId EncodingId;

        public InstructionId InstructionId;

        public MemoryAddress IP;

        public AsmHexCode Encoded;

        public Hex8 OpCode;

        public byte PSZ;

        public EmptyZero<RexPrefix> Rex;

        public VexPrefix Vex;

        public EvexPrefix Evex;

        public EmptyZero<ModRm> ModRm;

        public EmptyZero<Sib> Sib;

        public EmptyZero<Disp> Disp;

        public EmptyZero<Imm> Imm;

        public EmptyZero<SizeOverride> SZOV;

        public NativeSize EASZ;

        public NativeSize EOSZ;

        public AsmExpr Asm;

        public IFormType IForm;

        public @string SourceName;

        public EncodingOffsets Offsets;

        public OperandDetails Operands;

        public AsmRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public int CompareTo(AsmDisasmDetail src)
        {
            var result = SourceName.CompareTo(src.SourceName);
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
            ColWidths.Encoded,
            ColWidths.Hex8,
            ColWidths.Size,
            ColWidths.RexPrefx,
            ColWidths.VexPrefix,
            ColWidths.EvexPrefix,
            ColWidths.ModRm,
            ColWidths.Sib,
            ColWidths.Disp,
            ColWidths.Imm,
            ColWidths.Size,
            ColWidths.EASZ,
            ColWidths.EOSZ,
            ColWidths.AsmExpr,
            54,
            42,
            48,
            1};

        public static AsmDisasmDetail Empty => default;
    }
}