//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRecords;
    using static XedModels;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableName)]
    public struct XedDisasmDetail : IComparable<XedDisasmDetail>, IOriginated
    {
        public const string TableName = "xed.disasm.detail";

        public const byte FieldCount = 19;

        public uint Seq;

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

        public InstOperands Operands;

        Hex32 IOriginated.OriginId
            => OriginId;

        public int CompareTo(XedDisasmDetail src)
        {
            var result = SourceName.CompareTo(src.SourceName);
            if(result == 0)
                result = IP.CompareTo(src.IP);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,12,30,12,48,8,5,5,12,12,5,5,12,5,54,54,42,1};

        public static XedDisasmDetail Empty => default;

        // "{0,-12} | {1,-18} | {2,-12} | {3,-36} | {4,-8} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {9,-8} | {10,-8} | {11,-54} | {12,-54} | {13}"
    }
}