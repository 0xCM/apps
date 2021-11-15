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
        public readonly struct GpRm
        {
            public GpRmToken Token {get;}

            [MethodImpl(Inline)]
            public GpRm(GpRmToken token)
            {
                Token = token;
            }

            public K Kind => K.GpRm;

            [MethodImpl(Inline)]
            public static implicit operator GpRm(GpRmToken src)
                => new GpRm(src);

            [MethodImpl(Inline)]
            public static implicit operator GpRmToken(GpRm src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(GpRm src)
                => token(src.Kind, src);
        }
    }
}