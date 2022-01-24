//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;

    using K = AsmSigOpKind;

    partial class AsmSigModels
    {
        public readonly struct OpMask : IAsmSigOp<OpMask,OpMaskToken>
        {
            public Reg Reg {get;}

            public OpMaskToken Token {get;}

            [MethodImpl(Inline)]
            public OpMask(Reg r, OpMaskToken token)
            {
                Reg = r;
                Token = token;
            }

            public K OpKind => K.OpMask;

            [MethodImpl(Inline)]
            public static implicit operator OpMaskToken(OpMask src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(OpMask src)
                => sigop(src.OpKind, src);

            public static implicit operator Reg(OpMask src)
                => src.Reg;
        }
    }
}