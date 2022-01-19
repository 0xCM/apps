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
        public readonly struct m16 : IMemOpClass<m16>, IAsmSigOp<m16, MemToken>
        {
            public MemToken Token => MemToken.m16;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W16;

            [MethodImpl(Inline)]
            public static implicit operator mem(m16 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m16 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}