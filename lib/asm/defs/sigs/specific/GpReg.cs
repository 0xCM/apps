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
        public readonly struct GpReg
        {
            public GpRegToken Token {get;}

            [MethodImpl(Inline)]
            public GpReg(GpRegToken token)
            {
                Token = token;
            }

            public K Kind => K.GpReg;

            [MethodImpl(Inline)]
            public static implicit operator GpReg(GpRegToken src)
                => new GpReg(src);

            [MethodImpl(Inline)]
            public static implicit operator GpRegToken(GpReg src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(GpReg src)
                => token(src.Kind, src);
        }
    }
}