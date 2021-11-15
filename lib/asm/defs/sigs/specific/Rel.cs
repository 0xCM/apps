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
        public readonly struct Rel
        {
            public RelToken Token {get;}

            [MethodImpl(Inline)]
            public Rel(RelToken token)
            {
                Token = token;
            }

            public K Kind => K.Rel;

            [MethodImpl(Inline)]
            public static implicit operator Rel(RelToken src)
                => new Rel(src);

            [MethodImpl(Inline)]
            public static implicit operator RelToken(Rel src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(Rel src)
                => token(src.Kind, src);
        }
    }
}