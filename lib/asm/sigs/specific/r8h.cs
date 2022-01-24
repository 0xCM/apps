//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigModels
    {
        public readonly struct r8h : IRegOpClass<r8>, IAsmSigOp<r8h,GpRegToken>
        {
            public GpRegToken Token {get;}

            [MethodImpl(Inline)]
            public r8h(GpRegToken token = GpRegToken.r8)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W8;

            public RegClassCode RegClass
                => RegClassCode.GP8HI;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.GpReg;

            [MethodImpl(Inline)]
            public static implicit operator Reg(r8h src)
                => new Reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator GpReg(r8h src)
                => new GpReg(src.Token);

        }
    }
}