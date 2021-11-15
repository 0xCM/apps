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
        public readonly struct KReg
        {
            public MaskRegToken Token {get;}

            [MethodImpl(Inline)]
            public KReg(MaskRegToken token)
            {
                Token = token;
            }

            public K Kind => K.MaskReg;

            [MethodImpl(Inline)]
            public static implicit operator KReg(MaskRegToken src)
                => new KReg(src);

            [MethodImpl(Inline)]
            public static implicit operator MaskRegToken(KReg src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(KReg src)
                => token(src.Kind, src);
        }
    }
}