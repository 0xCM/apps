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
        public readonly struct Vsib
        {
            public VsibToken Token {get;}

            [MethodImpl(Inline)]
            public Vsib(VsibToken token)
            {
                Token = token;
            }

            public K Kind => K.Vsib;

            [MethodImpl(Inline)]
            public static implicit operator Vsib(VsibToken src)
                => new Vsib(src);

            [MethodImpl(Inline)]
            public static implicit operator VsibToken(Vsib src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(Vsib src)
                => token(src.Kind, src);
        }
    }
}