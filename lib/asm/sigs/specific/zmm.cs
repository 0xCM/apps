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
        public readonly struct zmm : IRegOpClass<zmm>, IAsmSigOp<zmm,VRegToken>
        {
            public VRegToken Token => VRegToken.zmm;

            public AsmSigOpKind Kind => AsmSigOpKind.ZmmReg;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W512;

            public RegClassCode RegClass
                => RegClassCode.ZMM;

            [MethodImpl(Inline)]
            public static implicit operator reg(zmm src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(zmm src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}