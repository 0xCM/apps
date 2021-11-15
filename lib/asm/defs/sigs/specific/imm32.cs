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
        public readonly struct imm32 : IImmOpClass<imm32>
        {
            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            public NativeSize Size
                => NativeSizeCode.W32;

            [MethodImpl(Inline)]
            public static implicit operator imm(imm32 src)
                => new imm(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(imm32 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}