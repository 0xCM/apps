//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        public static AsmSigExpr expression(AsmSigRuleExpr target)
        {
            var srcOps = target.Operands;
            var opcount = srcOps.Count;
            var dstOps = alloc<AsmSigOpExpr>(opcount);
            var dst = new AsmSigExpr(target.Mnemonic);
            for(byte i=0; i<opcount; i++)
                dst.WithOperand(i,sigop(srcOps[i]));
            return dst;
        }

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
            var count = min(ops.Length, AsmSigExpr.MaxOpCount);
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
    }
}
