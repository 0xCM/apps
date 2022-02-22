//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRecords;

    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct DisasmDetail
        {
            public const string TableName = "xed.disasm";

            public EncodingId EncodingId;

            public Hex32 DocId;

            public MemoryAddress IP;

            public AsmHexCode Encoded;

            public byte OpCode;

            public byte PrefixSize;

            public SizeOverride SizeOverride;

            public RexPrefix Rex;

            public ModRm ModRm;

            public Sib Sib;

            public Disp Disp;

            public AsmExpr Asm;

            public IFormType IForm;

            public Index<InstOperandDetail> Operands;
        }
    }
}