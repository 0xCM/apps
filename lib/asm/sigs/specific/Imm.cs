//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigModels
    {
        public readonly struct Imm : IImmOpClass<Imm>, IAsmSigOp<Imm,ImmToken>
        {
            public ImmToken Token {get;}

            public AsmSigOpKind OpKind
                => AsmSigOpKind.Imm;

            [MethodImpl(Inline)]
            public Imm(ImmToken token)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(Imm src)
                => asm.sigop(src.OpKind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator Imm(ImmToken src)
                => new Imm(src);
        }
    }
}