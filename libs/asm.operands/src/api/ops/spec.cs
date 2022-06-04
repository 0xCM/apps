//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [Op]
        public static AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, params AsmOperand[] ops)
        {
            var count = ops.Length;
            switch(count)
            {
                case 0:
                    return spec(mnemonic, opcode, out _);
                case 1:
                    return spec(mnemonic, opcode, skip(ops,0), out _);
                case 2:
                    return spec(mnemonic, opcode, skip(ops,0), skip(ops,1), out _);
                case 3:
                    return spec(mnemonic, opcode, skip(ops,0), skip(ops,1), skip(ops,2), out _);
                case 4:
                    return spec(mnemonic, opcode, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3), out _);
            }
            return AsmInstruction.Empty;
        }

        [MethodImpl(Inline), Op]
        public static AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperands ops)
        {
            var dst = AsmInstruction.Empty;
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            operands(op0, ref dst.Operands);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, in AsmOperand op1, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            operands(op0, op1, ref dst.Operands);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            operands(op0, op1, op2, ref dst.Operands);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmInstruction spec(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, out AsmInstruction dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            operands(op0, op1, op2, op3, ref dst.Operands);
            return ref dst;
        }
    }
}