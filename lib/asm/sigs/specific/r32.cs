//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        public readonly struct r32 : IRegOpClass<r32>, IAsmSigOp<r32,GpRegToken>
        {
            public GpRegToken Token => GpRegToken.r32;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W32;

            public RegClassCode RegClass
                => RegClassCode.GP;

            [MethodImpl(Inline)]
            public static implicit operator reg(r32 src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(r32 src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}