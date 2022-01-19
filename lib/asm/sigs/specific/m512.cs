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
        public readonly struct m512 : IMemOpClass<m512>, IAsmSigOp<m512, MemToken>
        {
            public MemToken Token => MemToken.m512;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W512;

            [MethodImpl(Inline)]
            public static implicit operator mem(m512 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m512 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}