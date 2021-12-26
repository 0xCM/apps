//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmSigOp sigop(AsmOpClass @class, AsmSigOpKind kind, NativeSize size)
            => new AsmSigOp(@class,kind,size);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic)
            => new AsmSig(mnemonic);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOp op0)
            => new AsmSig(mnemonic, op0);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1)
            => new AsmSig(mnemonic, op0, op1);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1, AsmSigOp op2)
            => new AsmSig(mnemonic, op0, op1, op2);

        [MethodImpl(Inline), Op]
        public static AsmSig sig(AsmMnemonic mnemonic, AsmSigOp op0, AsmSigOp op1, AsmSigOp op2, AsmSigOp op3)
            => new AsmSig(mnemonic, op0, op1, op2, op3);
    }
}