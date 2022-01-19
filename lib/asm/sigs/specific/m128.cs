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
        public readonly struct m128 : IMemOpClass<m128>, IAsmSigOp<m128, MemToken>
        {
            public MemToken Token => MemToken.m128;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W128;

            [MethodImpl(Inline)]
            public static implicit operator mem(m128 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m128 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}