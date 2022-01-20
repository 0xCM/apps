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
        public readonly struct GpReg : IAsmSigOp<GpReg,GpRegToken>
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

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(GpReg src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}