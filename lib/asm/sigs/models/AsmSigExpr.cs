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

    using api = AsmSigs;

    [StructLayout(LayoutKind.Sequential), DataType("asm.sig.expr")]
    public struct AsmSigExpr
    {
        public AsmMnemonic Mnemonic;

        internal AsmSigOpExpr Op0;

        internal AsmSigOpExpr Op1;

        internal AsmSigOpExpr Op2;

        internal AsmSigOpExpr Op3;

        public readonly byte OperandCount;

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic)
        {
            Mnemonic = monic;
            Op0 = AsmSigOpExpr.Empty;
            Op1 = AsmSigOpExpr.Empty;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 0;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = AsmSigOpExpr.Empty;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 1;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 2;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = AsmSigOpExpr.Empty;
            OperandCount = 3;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
            OperandCount = 4;
        }

        public ReadOnlySpan<AsmSigOpExpr> Operands()
        {
            var dst = alloc<AsmSigOpExpr>(OperandCount);
            Operands(dst);
            return dst;
        }

        public ref CharBlock64 OperandText(ref CharBlock64 dst)
        {
            var i=0u;
            api.operands(this, ref i, dst.Data);
            return ref dst;
        }

        public byte Operands(Span<AsmSigOpExpr> dst)
        {
            if(OperandCount >= 1)
            {
                seek(dst,0) = Op0;
                if(OperandCount >= 2)
                {
                    seek(dst,1) = Op1;
                    if(OperandCount >= 3)
                    {
                        seek(dst,2) = Op2;

                        if(OperandCount == 4)
                            seek(dst,3) = Op3;
                    }
                }
            }

            return OperandCount;
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

        public static AsmSigExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSigExpr(AsmMnemonic.Empty);
        }
    }
}