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
        public readonly struct imm8 : IImmOpClass<imm8>, IAsmSigOp<imm8,ImmToken>
        {
            public ImmToken Token => ImmToken.imm8;

            public AsmSigOpKind Kind => AsmSigOpKind.Imm;

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            public NativeSize Size
                => NativeSizeCode.W8;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(imm8 src)
                => asm.sigop(src.Kind, src.Token);
       }
    }
}