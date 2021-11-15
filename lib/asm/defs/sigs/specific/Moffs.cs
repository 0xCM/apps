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
        public readonly struct Moffs
        {
            public MoffsToken Token {get;}

            [MethodImpl(Inline)]
            public Moffs(MoffsToken token)
            {
                Token = token;
            }

            public K Kind => K.Moffs;

            [MethodImpl(Inline)]
            public static implicit operator Moffs(MoffsToken src)
                => new Moffs(src);

            [MethodImpl(Inline)]
            public static implicit operator MoffsToken(Moffs src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(Moffs src)
                => token(src.Kind, src);
        }
    }
}