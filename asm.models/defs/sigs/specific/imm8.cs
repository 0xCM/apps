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
        public readonly struct imm8 : IImmOpClass<imm8>
        {
            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            public NativeSize Size
                => NativeSizeCode.W8;

            [MethodImpl(Inline)]
            public static implicit operator imm(imm8 src)
                => new imm(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(imm8 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}