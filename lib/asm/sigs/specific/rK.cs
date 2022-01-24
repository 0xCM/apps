//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;

    using K = AsmSigOpKind;

    partial class AsmSigModels
    {
        public readonly struct rK : IRegOpClass<rK>, IAsmSigOp<rK,MaskRegToken>
        {
            public MaskRegToken Token
                => MaskRegToken.rK;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.MASK;

            public K OpKind => K.MaskReg;

            [MethodImpl(Inline)]
            public static implicit operator MaskRegToken(rK src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(rK src)
                => sigop(src.OpKind, src);

            [MethodImpl(Inline)]
            public static implicit operator Reg(rK src)
                => new Reg(src.Size, src.RegClass);
        }
    }
}