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
        public readonly struct FpuMem
        {
            public FpuMemToken Token {get;}

            [MethodImpl(Inline)]
            public FpuMem(FpuMemToken token)
            {
                Token = token;
            }

            public K Kind => K.FpuMem;

            [MethodImpl(Inline)]
            public static implicit operator FpuMem(FpuMemToken src)
                => new FpuMem(src);

            [MethodImpl(Inline)]
            public static implicit operator FpuMemToken(FpuMem src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(FpuMem src)
                => token(src.Kind, src);
        }
    }
}