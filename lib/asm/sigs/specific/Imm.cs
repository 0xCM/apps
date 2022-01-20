//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;

    partial class AsmSigModels
    {
        public readonly struct imm : IImmOpClass<imm>
        {
            public NativeSize Size {get;}

            public AsmSigOpKind Kind => AsmSigOpKind.Imm;

            [MethodImpl(Inline)]
            public imm(NativeSize size)
            {
                Size = size;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Imm;

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(imm src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}