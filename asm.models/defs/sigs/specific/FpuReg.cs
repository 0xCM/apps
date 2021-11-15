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
        public readonly struct FpuReg
        {
            public FpuRegToken Token {get;}

            [MethodImpl(Inline)]
            public FpuReg(FpuRegToken token)
            {
                Token = token;
            }

            public K Kind => K.FpuReg;

            [MethodImpl(Inline)]
            public static implicit operator FpuReg(FpuRegToken src)
                => new FpuReg(src);

            [MethodImpl(Inline)]
            public static implicit operator FpuRegToken(FpuReg src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(FpuReg src)
                => token(src.Kind, src);
        }
    }
}