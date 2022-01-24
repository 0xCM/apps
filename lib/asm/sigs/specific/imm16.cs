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
        public readonly struct imm16 : IImmOpClass<imm16>, IAsmSigOp<imm16,ImmToken>
        {
            public ImmToken Token
                => ImmToken.imm16;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.Imm;

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            public NativeSize Size
                => NativeSizeCode.W16;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(imm16 src)
                => asm.sigop(src.OpKind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator Imm(imm16 src)
                => new Imm(src.Token);
        }
    }
}