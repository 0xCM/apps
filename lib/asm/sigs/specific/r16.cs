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
        public readonly struct r16 : IRegOpClass<r16>, IAsmSigOp<r16,GpRegToken>
        {

             public GpRegToken Token => GpRegToken.r16;

             public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W16;

            public RegClassCode RegClass
                => RegClassCode.GP;

            [MethodImpl(Inline)]
            public static implicit operator reg(r16 src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(r16 src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}