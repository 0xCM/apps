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
        public readonly struct r32 : IRegOpClass<r32>, IAsmSigOp<r32,GpRegToken>
        {
            public GpRegToken Token {get;}

            [MethodImpl(Inline)]
            public r32(GpRegToken token = GpRegToken.r32)
            {
                Token = token;
            }
            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W32;

            public RegClassCode RegClass
                => RegClassCode.GP;

            [MethodImpl(Inline)]
            public static implicit operator reg(r32 src)
                => new reg(src.Size, src.RegClass);

        }
    }
}