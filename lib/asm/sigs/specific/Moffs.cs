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
        public readonly struct Moffs : IAsmSigOp<Moffs,MoffsToken>
        {
            public MoffsToken Token {get;}

            [MethodImpl(Inline)]
            public Moffs(MoffsToken token)
            {
                Token = token;
            }

            public K OpKind => K.Moffs;

            [MethodImpl(Inline)]
            public static implicit operator Moffs(MoffsToken src)
                => new Moffs(src);

            [MethodImpl(Inline)]
            public static implicit operator MoffsToken(Moffs src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(Moffs src)
                => sigop(src.OpKind, src);
        }
    }
}