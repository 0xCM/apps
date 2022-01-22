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
        public readonly struct imm64 : IImmOpClass<imm64>, IAsmSigOp<imm64,ImmToken>
        {
            public ImmToken Token
                => ImmToken.imm64;

            public AsmSigOpKind Kind
                => AsmSigOpKind.Imm;

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            public NativeSize Size
                => NativeSizeCode.W64;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(imm64 src)
                => asm.sigop(src.Kind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator Imm(imm64 src)
                => new Imm(src.Token);

        }
    }
}