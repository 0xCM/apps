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
        public readonly struct ymm : IRegOpClass<ymm>, IAsmSigOp<ymm,VRegToken>
        {

            public VRegToken Token => VRegToken.ymm;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W256;

            public RegClassCode RegClass
                => RegClassCode.YMM;

            [MethodImpl(Inline)]
            public static implicit operator reg(ymm src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(ymm src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}