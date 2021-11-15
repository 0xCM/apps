//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using K = AsmSigTokenKind;

    partial class AsmSigs
    {
        public readonly struct Broadcast
        {
            public BroadcastToken Token {get;}

            [MethodImpl(Inline)]
            public Broadcast(BroadcastToken token)
            {
                Token = token;
            }

            public K Kind => K.Broadcast;

            [MethodImpl(Inline)]
            public static implicit operator Broadcast(BroadcastToken src)
                => new Broadcast(src);

            [MethodImpl(Inline)]
            public static implicit operator BroadcastToken(Broadcast src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(Broadcast src)
                => token(src.Kind, src);
        }
    }
}