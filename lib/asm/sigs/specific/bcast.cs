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
        public readonly struct bcast : IAsmSigOp<bcast,BroadcastToken>
        {
            public BroadcastToken Token {get;}

            [MethodImpl(Inline)]
            public bcast(BroadcastToken token)
            {
                Token = token;
            }

            public K Kind => K.Broadcast;

            [MethodImpl(Inline)]
            public static implicit operator bcast(BroadcastToken src)
                => new bcast(src);

            [MethodImpl(Inline)]
            public static implicit operator BroadcastToken(bcast src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(bcast src)
                => asm.sigop(src.Kind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(bcast src)
                => token(src.Kind, src);
        }
    }
}