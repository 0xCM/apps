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
        public readonly struct GpRm : IAsmSigOp<GpRm,GpRmToken>
        {
            public GpRmToken Token {get;}

            [MethodImpl(Inline)]
            public GpRm(GpRmToken token)
            {
                Token = token;
            }

            public K OpKind => K.GpRm;

            [MethodImpl(Inline)]
            public static implicit operator GpRm(GpRmToken src)
                => new GpRm(src);

            [MethodImpl(Inline)]
            public static implicit operator GpRmToken(GpRm src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(GpRm src)
                => sigop(src.OpKind, src);
        }
    }
}