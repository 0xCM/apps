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
        public readonly struct Rel : IAsmSigOp<Rel,RelToken>
        {
            public RelToken Token {get;}

            [MethodImpl(Inline)]
            public Rel(RelToken token)
            {
                Token = token;
            }

            public K OpKind
                => K.Rel;

            [MethodImpl(Inline)]
            public static implicit operator Rel(RelToken src)
                => new Rel(src);

            [MethodImpl(Inline)]
            public static implicit operator RelToken(Rel src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(Rel src)
                => sigop(src.OpKind, src);
        }
    }
}