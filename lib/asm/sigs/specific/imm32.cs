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
        public readonly struct imm32 : IImmOpClass<imm32>, IAsmSigOp<imm32,ImmToken>
        {
            public ImmToken Token
                => ImmToken.imm32;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.Imm;

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            public NativeSize Size
                => NativeSizeCode.W32;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(imm32 src)
                => asm.sigop(src.OpKind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator Imm(imm32 src)
                => new Imm(src.Token);
        }
    }
}