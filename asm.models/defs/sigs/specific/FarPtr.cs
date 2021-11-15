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
        public readonly struct FarPtr
        {
            public FarPtrToken Token {get;}

            [MethodImpl(Inline)]
            public FarPtr(FarPtrToken token)
            {
                Token = token;
            }

            public K Kind => K.FarPtr;

            [MethodImpl(Inline)]
            public static implicit operator FarPtr(FarPtrToken src)
                => new FarPtr(src);

            [MethodImpl(Inline)]
            public static implicit operator FarPtrToken(FarPtr src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(FarPtr src)
                => token(src.Kind, src);
        }
    }
}