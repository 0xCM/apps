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
        public readonly struct m64 : IMemOpClass<m64>, IAsmSigOp<m64, MemToken>
        {
            public MemToken Token => MemToken.m64;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W64;

            [MethodImpl(Inline)]
            public static implicit operator mem(m64 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m64 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}