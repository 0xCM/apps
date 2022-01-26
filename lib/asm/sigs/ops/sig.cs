//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigModels;
    using static core;

    partial class AsmSigs
    {
        [Op]
        public static AsmSig sig(AsmMnemonic mnemonic, params AsmSigOp[] ops)
            => ops.Length switch{
                0 => new AsmSig(mnemonic),
                1 => new AsmSig(mnemonic, skip(ops,0)),
                2 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1)),
                3 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2)),
                4 => new AsmSig(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3)),
                _ => AsmSig.Empty
            };
    }
}