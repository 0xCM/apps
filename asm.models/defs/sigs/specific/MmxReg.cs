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
        public readonly struct MmxReg
        {
            public MmxRegToken Token {get;}

            [MethodImpl(Inline)]
            public MmxReg(MmxRegToken token)
            {
                Token = token;
            }

            public K Kind => K.MmxReg;

            [MethodImpl(Inline)]
            public static implicit operator MmxReg(MmxRegToken src)
                => new MmxReg(src);

            [MethodImpl(Inline)]
            public static implicit operator MmxRegToken(MmxReg src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(MmxReg src)
                => token(src.Kind, src);
        }
    }
}