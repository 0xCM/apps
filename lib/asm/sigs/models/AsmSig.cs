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

    [StructLayout(LayoutKind.Sequential,Pack=1), DataType("asm.sig")]
    public readonly struct AsmSig
    {
        public readonly AsmMnemonic Mnemonic;

        public readonly AsmSigOps Operands;

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic, AsmSigOps operands)
        {
            Mnemonic = mnemonic;
            Operands = operands;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic)
        {
            Mnemonic = mnemonic;
            Operands = AsmSigOps.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic, AsmSigOp op0)
        {
            Mnemonic = mnemonic;
            Operands.Op0 = op0;
            Operands.Op1 = AsmSigOp.Empty;
            Operands.Op2 = AsmSigOp.Empty;
            Operands.Op3 = AsmSigOp.Empty;
            Operands.Op4 = AsmSigOp.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1)
        {
            Mnemonic = mnemonic;
            Operands.Op0 = op0;
            Operands.Op1 = op1;
            Operands.Op2 = AsmSigOp.Empty;
            Operands.Op3 = AsmSigOp.Empty;
            Operands.Op4 = AsmSigOp.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1, AsmSigOp op2)
        {
            Mnemonic = mnemonic;
            Operands.Op0 = op0;
            Operands.Op1 = op1;
            Operands.Op2 = op2;
            Operands.Op3 = AsmSigOp.Empty;
            Operands.Op4 = AsmSigOp.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1, AsmSigOp op2, AsmSigOp op3)
        {
            Mnemonic = mnemonic;
            Operands.Op0 = op0;
            Operands.Op1 = op1;
            Operands.Op2 = op2;
            Operands.Op3 = op3;
            Operands.Op4 = AsmSigOp.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1, AsmSigOp op2, AsmSigOp op3, AsmSigOp op4)
        {
            Mnemonic = mnemonic;
            Operands.Op0 = op0;
            Operands.Op1 = op1;
            Operands.Op2 = op2;
            Operands.Op3 = op3;
            Operands.Op4 = op4;
        }

        public AsmSigOp this[int i]
            => Operands[i];

        public byte OpCount
        {
            [MethodImpl(Inline)]
            get => Operands.OpCount;
        }

        public string Format()
            => AsmSigFormatter.format(this);

        public override string ToString()
            => Format();

        public static AsmSig Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSig(AsmMnemonic.Empty);
        }
    }
}