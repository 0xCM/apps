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

    using api = AsmSigs;

    [StructLayout(LayoutKind.Sequential)]
    public struct AsmSig
    {
        public AsmMnemonic Mnemonic;

        internal AsmSigOpExpr Op0;

        internal AsmSigOpExpr Op1;

        internal AsmSigOpExpr Op2;

        internal AsmSigOpExpr Op3;

        public readonly byte OperandCount;

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic monic)
        {
            Mnemonic = monic;
            Op0 = AsmSigOpExpr.Empty;
            Op1 = AsmSigOpExpr.Empty;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 0;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic monic, AsmSigOpExpr op0)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = AsmSigOpExpr.Empty;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 1;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 2;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 3;
        }

        [MethodImpl(Inline)]
        public AsmSig(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
            OperandCount = 4;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Mnemonic.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Mnemonic.IsNonEmpty;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static AsmSig Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSig(AsmMnemonic.Empty);
        }
    }
}