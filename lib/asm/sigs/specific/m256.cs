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
        public readonly struct m256 : IMemOpClass<m256>, IAsmSigOp<m256, MemToken>
        {
            public MemToken Token => MemToken.m256;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W256;

            [MethodImpl(Inline)]
            public static implicit operator mem(m256 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m256 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}