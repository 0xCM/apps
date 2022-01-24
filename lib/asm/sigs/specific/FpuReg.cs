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
        public readonly struct FpuReg : IRegOpClass<FpuReg>, IAsmSigOp<FpuReg,FpuRegToken>
        {
            public FpuRegToken Token {get;}

            [MethodImpl(Inline)]
            public FpuReg(FpuRegToken token)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W80;

            public RegClassCode RegClass
                => RegClassCode.ST;

            public K OpKind => K.FpuReg;

            [MethodImpl(Inline)]
            public static implicit operator FpuReg(FpuRegToken src)
                => new FpuReg(src);

            [MethodImpl(Inline)]
            public static implicit operator FpuRegToken(FpuReg src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(FpuReg src)
                => sigop(src.OpKind, src);
        }
    }
}