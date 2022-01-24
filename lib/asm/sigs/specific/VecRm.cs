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
        public readonly struct VecRm
        {
            public VecRmToken Token {get;}

            [MethodImpl(Inline)]
            public VecRm(VecRmToken token)
            {
                Token = token;
            }

            public K Kind => K.VecRm;

            [MethodImpl(Inline)]
            public static implicit operator VecRm(VecRmToken src)
                => new VecRm(src);

            [MethodImpl(Inline)]
            public static implicit operator VecRmToken(VecRm src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(VecRm src)
                => sigop(src.Kind, src);
        }
    }
}