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
        public readonly struct SrcOp
        {
            public SrcOpToken Token {get;}

            [MethodImpl(Inline)]
            public SrcOp(SrcOpToken token)
            {
                Token = token;
            }

            public K Kind => K.SrcOp;

            [MethodImpl(Inline)]
            public static implicit operator SrcOp(SrcOpToken src)
                => new SrcOp(src);

            [MethodImpl(Inline)]
            public static implicit operator SrcOpToken(SrcOp src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(SrcOp src)
                => token(src.Kind, src);
        }
    }
}