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
            public OpMaskToken Token {get;}

            [MethodImpl(Inline)]
            public OpMask(OpMaskToken token)
            {
                Token = token;
            }

            public K Kind => K.OpMask;

            [MethodImpl(Inline)]
            public static implicit operator OpMask(OpMaskToken src)
                => new OpMask(src);

            [MethodImpl(Inline)]
            public static implicit operator OpMaskToken(OpMask src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(OpMask src)
                => token(src.Kind, src);
        }
    }
}