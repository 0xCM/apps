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
        public readonly struct FarPtr : IAsmSigOp<FarPtr,FarPtrToken>
        {
            public FarPtrToken Token {get;}

            [MethodImpl(Inline)]
            public FarPtr(FarPtrToken token)
            {
                Token = token;
            }

            public K OpKind => K.FarPtr;

            [MethodImpl(Inline)]
            public static implicit operator FarPtr(FarPtrToken src)
                => new FarPtr(src);

            [MethodImpl(Inline)]
            public static implicit operator FarPtrToken(FarPtr src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(FarPtr src)
                => sigop(src.OpKind, src);
        }
    }
}