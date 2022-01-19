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
        public readonly struct r8 : IRegOpClass<r8>, IAsmSigOp<r8,GpRegToken>
        {
             public GpRegToken Token => GpRegToken.r8;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W8;

            public RegClassCode RegClass
                => RegClassCode.GP;

            [MethodImpl(Inline)]
            public static implicit operator reg(r8 src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(r8 src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}