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
        public readonly struct Xmm : IRegOpClass<Xmm>, IAsmSigOp<Xmm,VRegToken>
        {
            public VRegToken Token => VRegToken.xmm;

            public AsmSigOpKind Kind => AsmSigOpKind.XmmReg;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W128;

            public RegClassCode RegClass
                => RegClassCode.XMM;

            [MethodImpl(Inline)]
            public static implicit operator Reg(Xmm src)
                => new Reg(src.Size, src.RegClass);
        }
    }
}