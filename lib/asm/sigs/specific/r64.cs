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
        public readonly struct r64 : IRegOpClass<r64>, IAsmSigOp<r64,GpRegToken>
        {
            public GpRegToken Token {get;}

            [MethodImpl(Inline)]
            public r64(GpRegToken token = GpRegToken.r64)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.GP;

            [MethodImpl(Inline)]
            public static implicit operator reg(r64 src)
                => new reg(src.Size, src.RegClass);

        }
    }
}