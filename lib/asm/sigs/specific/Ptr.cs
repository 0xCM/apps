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
        public readonly struct Ptr : IAsmSigOp<Ptr,PtrToken>
        {
            public PtrToken Token {get;}

            [MethodImpl(Inline)]
            public Ptr(PtrToken token)
            {
                Token = token;
            }

            public K Kind => K.Ptr;

            [MethodImpl(Inline)]
            public static implicit operator Ptr(PtrToken src)
                => new Ptr(src);

            [MethodImpl(Inline)]
            public static implicit operator PtrToken(Ptr src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(Ptr src)
                => token(src.Kind, src);
        }
    }
}