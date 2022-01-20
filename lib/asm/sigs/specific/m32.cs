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
        public readonly struct m32 : IMemOpClass<m32>, IAsmSigOp<m32, MemToken>
        {
            public MemToken Token => MemToken.m32;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W32;

            [MethodImpl(Inline)]
            public static implicit operator mem(m32 src)
                => new mem(src.Size);


            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m32 src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}