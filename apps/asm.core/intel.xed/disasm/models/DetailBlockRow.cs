//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableName)]
        public record struct DetailBlockRow : IComparable<DetailBlockRow>
        {
            public const string TableName = "xed.disasm.detail";

            public const byte FieldCount = 26;

            public uint Seq;

            public uint DocSeq;

            public Hex32 OriginId;

            public @string OriginName;

            public EncodingId EncodingId;

            public InstructionId InstructionId;

            public MemoryAddress IP;

            public InstClass InstClass;

            public AsmHexCode Encoded;

            public Hex8 OpCode;

            public byte PSZ;

            public RexPrefix Rex;

            public VexPrefix Vex;

            public EvexPrefix Evex;

            public ModRm ModRm;

            public Sib Sib;

            public EmptyZero<Disp> Disp;

            public EmptyZero<Imm> Imm;

            public SizeOverride SZOV;

            public NativeSize EASZ;

            public NativeSize EOSZ;

            public AsmExpr Asm;

            public InstForm InstForm;

            public @string SourceName;

            public EncodingOffsets Offsets;

            public OpDetails Ops;

            public int CompareTo(DetailBlockRow src)
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
                ColWidths.Mnemonic,
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
                ColWidths.IForm,
                ColWidths.OriginName,
                48,
                1};

            public static DetailBlockRow Empty => default;
        }
    }
}