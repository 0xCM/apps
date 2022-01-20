//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;

    partial class AsmSigModels
    {
        public readonly struct imm : IImmOpClass<imm>, IAsmSigOp<imm,ImmToken>
        {
            public ImmToken Token {get;}

            public AsmSigOpKind Kind => AsmSigOpKind.Imm;

            [MethodImpl(Inline)]
            public imm(ImmToken token)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(imm src)
                => asm.sigop(src.Kind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator imm(ImmToken src)
                => new imm(src);
        }
    }
}