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
            public AsmCode Code;

            public IClass IClass;

            public IFormType IForm;

            public Index<InstOperandDetail> Operands;

            public byte PrefixSize;

            public SizeOverride SizeOverride;

            public RexPrefix Rex;

            public byte OpCode;

            public ModRm ModRm;

            public Sib Sib;

            public Disp Disp;

            public Hex64 Id
            {
                [MethodImpl(Inline)]
                get => Code.Id;
            }

            public MemoryAddress IP
            {
                [MethodImpl(Inline)]
                get => Code.IP;
            }

            public SourceText Asm
            {
                [MethodImpl(Inline)]
                get => Code.Asm;
            }

            public AsmHexRef Encoded
            {
                [MethodImpl(Inline)]
                get => Code.Encoded;
            }
        }
    }
}