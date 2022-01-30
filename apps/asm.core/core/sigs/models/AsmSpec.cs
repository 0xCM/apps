//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmSpec
    {
        internal static string format(in AsmSpec src)
        {
            var dst = text.buffer();
            ref readonly var ops = ref src.Operands;
            var count = ops.OpCount;
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            switch(count)
            {
                case 0:
                break;
                case 1:
                    dst.AppendFormat(" {0}", ops.Op0);
                break;
                case 2:
                    dst.AppendFormat(" {0}, {1}", ops.Op0, ops.Op1);
                break;
                case 3:
                    dst.AppendFormat(" {0}, {1}, {2}", ops.Op0, ops.Op1, ops.Op2);
                break;
                case 4:
                    dst.AppendFormat(" {0}, {1}, {2}, {3}", ops.Op0, ops.Op1, ops.Op2, ops.Op3);
                break;
            }
            return dst.Emit();
        }

        [Op]
        public static AsmSpec define(in AsmMnemonic mnemonic, in AsmOpCode opcode, params AsmOperand[] ops)
        {
            var count = ops.Length;
            switch(count)
            {
                case 0:
                    return define(mnemonic, opcode, out _);
                case 1:
                    return define(mnemonic, opcode, skip(ops,0), out _);
                case 2:
                    return define(mnemonic, opcode, skip(ops,0), skip(ops,1), out _);
                case 3:
                    return define(mnemonic, opcode, skip(ops,0),skip(ops,1), skip(ops,2), out _);
                case 4:
                    return define(mnemonic, opcode, skip(ops,0),skip(ops,1), skip(ops,2), skip(ops,3), out _);
            }
            return AsmSpec.Empty;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOpCode opcode, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 1;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = AsmOperand.Empty;
            dst.Operands.Op2 = AsmOperand.Empty;
            dst.Operands.Op3 = AsmOperand.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, in AsmOperand op1, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 2;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = op1;
            dst.Operands.Op2 = AsmOperand.Empty;
            dst.Operands.Op3 = AsmOperand.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 3;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = op1;
            dst.Operands.Op2 = op2;
            dst.Operands.Op3 = AsmOperand.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOpCode opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 4;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = op1;
            dst.Operands.Op2 = op2;
            dst.Operands.Op3 = op3;
            return ref dst;
        }

        public AsmMnemonic Mnemonic;

        public AsmOpCode OpCode;

        public AsmOperands Operands;

        public static AsmSpec Empty => default;

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}