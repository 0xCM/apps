//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using K = AsmSigOpKind;

    partial class AsmSigs
    {
        public readonly struct rK : IRegOpClass<rK>, IAsmSigOp<rK,MaskRegToken>
        {
            public MaskRegToken Token => MaskRegToken.rK;

            public AsmOpClass OpClass
                => AsmOpClass.Reg;

            public NativeSize Size
                => NativeSizeCode.W64;

            public RegClassCode RegClass
                => RegClassCode.MASK;

            public K Kind => K.MaskReg;

            [MethodImpl(Inline)]
            public static implicit operator MaskRegToken(rK src)
                => src.Token;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigToken(rK src)
                => token(src.Kind, src);

            [MethodImpl(Inline)]
            public static implicit operator reg(rK src)
                => new reg(src.Size, src.RegClass);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(rK src)
                => new AsmOperand(src.OpClass, src.Size, (byte)src.RegClass);
        }
    }
}