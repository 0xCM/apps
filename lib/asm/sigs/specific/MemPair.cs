//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using K = AsmSigOpKind;

    partial class AsmSigs
    {
        public readonly struct MemPair : IAsmSigOp<MemPair, MemPairToken>
        {
            public MemPairToken Token {get;}

            [MethodImpl(Inline)]
            public MemPair(MemPairToken token)
            {
                Token = token;
            }

            public K Kind => K.MemPair;

            [MethodImpl(Inline)]
            public static implicit operator MemPair(MemPairToken src)
                => new MemPair(src);

            [MethodImpl(Inline)]
            public static implicit operator MemPairToken(MemPair src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(MemPair src)
                => token(src.Kind, src);
        }
    }
}