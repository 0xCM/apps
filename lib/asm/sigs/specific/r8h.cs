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

            [MethodImpl(Inline)]
            public static implicit operator reg(r8h src)
                => new reg(src.Size, src.RegClass);

        }
    }
}