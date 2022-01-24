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
        public readonly struct Zmm : IRegOpClass<Zmm>, IAsmSigOp<Zmm,VRegToken>
        {
            public VRegToken Token
                => VRegToken.zmm;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.ZmmReg;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W512;

            public RegClassCode RegClass
                => RegClassCode.ZMM;

            [MethodImpl(Inline)]
            public static implicit operator Reg(Zmm src)
                => new Reg(src.Size, src.RegClass);
        }
    }
}