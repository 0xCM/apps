//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class AsmSigs
    {
        [MethodImpl(Inline)]
        public static AsmSig sig(AsmMnemonic mnemonic)
            =>  new AsmSig(mnemonic);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOpExpr op0)
            => new AsmSig(mnemonic, op0);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1)
            => new AsmSig(mnemonic, op0, op1);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
            => new AsmSig(mnemonic, op0, op1, op2);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
            => new AsmSig(mnemonic, op0, op1, op2, op3);

        [Op]
        public static AsmSig sig(AsmMnemonic mnemonic, ReadOnlySpan<string> ops)
        {
            var count = min(ops.Length, 4);
            switch(count)
            {
                case 1:
                    return sig(mnemonic, skip(ops, 0));
                case 2:
                    return sig(mnemonic, skip(ops, 0), skip(ops, 1));
                case 3:
                    return sig(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2));
                case 4:
                    return sig(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3));
            }

            return sig(mnemonic);
        }
    }
}