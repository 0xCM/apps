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
        public readonly struct BCast : IAsmSigOp<BCast,BroadcastToken>
        {
            public BroadcastToken Token {get;}

            [MethodImpl(Inline)]
            public BCast(BroadcastToken token)
            {
                Token = token;
            }

            public K OpKind => K.Broadcast;

            [MethodImpl(Inline)]
            public static implicit operator BCast(BroadcastToken src)
                => new BCast(src);

            [MethodImpl(Inline)]
            public static implicit operator BroadcastToken(BCast src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(BCast src)
                => sigop(src.OpKind, src);
        }
    }
}