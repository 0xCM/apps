//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmInstruction : IAsmSourcePart
    {
        public AsmMnemonic Mnemonic;

        public AsmOpCode OpCode;

        public AsmOperands Operands;

        public AsmInstruction(AsmMnemonic mnemonic, AsmOpCode opcode, AsmOperands ops)
        {
            Mnemonic = mnemonic;
            OpCode = opcode;
            Operands = ops;
        }

        public string Format()
            => AsmRender.instruction(this);

        public override string ToString()
            => Format();

        public static AsmInstruction Empty => default;

        public AsmPartKind PartKind
            => AsmPartKind.Instruction;
    }
}