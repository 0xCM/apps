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
        public readonly struct r8 : IRegOpClass<r8>, IAsmSigOp<r8,GpRegToken>
        {
            public GpRegToken Token {get;}

            [MethodImpl(Inline)]
            public r8(GpRegToken token = GpRegToken.r8)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.GpReg;

            public NativeSize Size
                => NativeSizeCode.W8;

            public RegClassCode RegClass
                => RegClassCode.GP;

            [MethodImpl(Inline)]
            public static implicit operator Reg(r8 src)
                => new Reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator GpReg(r8 src)
                => new GpReg(src.Token);
        }
    }
}