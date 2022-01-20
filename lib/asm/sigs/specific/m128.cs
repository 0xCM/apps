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
        public readonly struct m128 : IMemOpClass<m128>, IAsmSigOp<m128, MemToken>
        {
            public MemToken Token => MemToken.m128;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W128;

            [MethodImpl(Inline)]
            public static implicit operator mem(m128 src)
                => new mem(src.Size);


            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m128 src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}