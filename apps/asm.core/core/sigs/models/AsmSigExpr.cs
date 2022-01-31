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

    [StructLayout(LayoutKind.Sequential, Pack=1), DataType("asm.sig.expr")]
    public struct AsmSigExpr : IEquatable<AsmSigExpr>
    {
        public const byte MaxOpCount = 5;

        [MethodImpl(Inline)]
        public static AsmSigExpr expression(AsmMnemonic mnemonic)
            =>  new AsmSigExpr(mnemonic);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0)
            => new AsmSigExpr(mnemonic, op0);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1)
            => new AsmSigExpr(mnemonic, op0, op1);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
            => new AsmSigExpr(mnemonic, op0, op1, op2);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
            => new AsmSigExpr(mnemonic, op0, op1, op2, op3);

        [MethodImpl(Inline), Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3, AsmSigOpExpr op4)
            => new AsmSigExpr(mnemonic, op0, op1, op2, op3, op4);

        [Op]
        public static AsmSigExpr expression(AsmMnemonic mnemonic, ReadOnlySpan<string> ops)
        {
            var count = min(ops.Length, MaxOpCount);
            switch(count)
            {
                case 1:
                    return expression(mnemonic, skip(ops, 0));
                case 2:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1));
                case 3:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2));
                case 4:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3));
                case 5:
                    return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3), skip(ops, 4));
            }

            return expression(mnemonic);
        }

        [MethodImpl(Inline), Op]
        public static ref readonly AsmSigOpExpr operand(in AsmSigExpr src, byte i)
        {
            if(i==0)
                return ref src.Op0;
            if(i==1)
                return ref src.Op1;
            if(i==2)
                return ref src.Op2;
            if(i==3)
                return ref src.Op3;
            return ref src.Op4;
        }

        [Op]
        public static uint operands(in AsmSigExpr src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.OperandCount;
            for(byte j=0; j<count; j++)
            {
                ref readonly var op = ref operand(src,j);
                if(op.IsEmpty)
                    break;

                if(j != 0)
                {
                    seek(dst,i++) = Chars.Comma;
                    seek(dst,i++) = Chars.Space;
                }

                text.copy(op.Text, ref i, dst);
            }

            return i - i0;
        }

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
            operands(this, ref i, dst.Data);
            return ref dst;
        }

        [MethodImpl(Inline)]
        byte CalcOpCount()
        {
            var count = z8;
            if(Op0.IsEmpty)
                return 0;
            if(Op1.IsEmpty)
                return 1;
            if(Op2.IsEmpty)
                return 2;
            if(Op3.IsEmpty)
                return 3;
            if(Op4.IsEmpty)
                return 4;

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

        public bool Equals(AsmSigExpr src)
        {
            if(Mnemonic != src.Mnemonic)
                return false;

            var count = OperandCount;

            if(count != src.OperandCount)
                return false;

            var ops = Operands();
            var srcOps = src.Operands();
            var result = true;
            for(var i=0; i<count; i++)
                result &= skip(ops,i).Equals(skip(srcOps,i));
            return result;
        }

        public string Format()
            => AsmSigFormatter.format(this);

        public override string ToString()
            => Format();

        public static AsmSigExpr Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSigExpr(AsmMnemonic.Empty);
        }
    }
}