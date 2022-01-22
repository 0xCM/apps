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
        public static AsmSig sig(AsmOpCode opcode, AsmMnemonic mnemonic, params AsmSigOp[] ops)
            => AsmSigs.sig(opcode, mnemonic, ops);
    }
}