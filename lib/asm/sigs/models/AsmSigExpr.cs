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

    [StructLayout(LayoutKind.Sequential, Pack=1), DataType("asm.sig.expr")]
    public struct AsmSigExpr
    {
        public readonly AsmMnemonic Mnemonic;

        public AsmSigOpExpr Op0;

        public AsmSigOpExpr Op1;

        public AsmSigOpExpr Op2;

        public AsmSigOpExpr Op3;

        public AsmSigOpExpr Op4;

        public byte OperandCount
        {
            [MethodImpl(Inline)]
            get => CalcOpCount();
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic)
        {
            Mnemonic = monic;
            Op0 = AsmSigOpExpr.Empty;
            Op1 = AsmSigOpExpr.Empty;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            Op4 = AsmSigOpExpr.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = AsmSigOpExpr.Empty;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            Op4 = AsmSigOpExpr.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = AsmSigOpExpr.Empty;
            Op3 = AsmSigOpExpr.Empty;
            Op4 = AsmSigOpExpr.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = AsmSigOpExpr.Empty;
            Op4 = AsmSigOpExpr.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
            Op4 = AsmSigOpExpr.Empty;
        }

        [MethodImpl(Inline)]
        public AsmSigExpr(AsmMnemonic monic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3, AsmSigOpExpr op4)
        {
            Mnemonic = monic;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
            Op4 = op4;
        }

        public AsmSigExpr WithOperand(byte n, AsmSigOpExpr op)
        {
            switch(n)
            {
                case 0:
                    Op0 = op;
                break;
                case 1:
                    Op1 = op;
                break;
                case 2:
                    Op2 = op;
                break;
                case 3:
                    Op3 = op;
                break;
                case 4:
                    Op4 = op;
                break;
            }
            return this;
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

        [MethodImpl(Inline)]
        byte CalcOpCount()
        {
            if(Op4.IsEmpty)
            {
                if(Op3.IsEmpty)
                {
                    if(Op2.IsEmpty)
                    {
                        if(Op1.IsEmpty)
                        {
                            if(Op0.IsEmpty)
                                return 0;
                            else
                                return 1;
                        }
                        else
                            return 2;
                    }
                    else
                        return 3;
                }
                else
                    return 4;
                }
            else
                return 5;
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

                        if(OperandCount >= 4)
                        {
                            seek(dst,3) = Op3;

                            if(OperandCount >= 5)
                                seek(dst,4) = Op4;
                        }
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