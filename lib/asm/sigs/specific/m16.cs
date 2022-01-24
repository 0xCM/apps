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
        public readonly struct m16 : IMemOpClass<m16>, IAsmSigOp<m16, MemToken>
        {
            public MemToken Token
                => MemToken.m16;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.Mem;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W16;

            [MethodImpl(Inline)]
            public static implicit operator Mem(m16 src)
                => new Mem(src.Token);

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m16 src)
                => asm.sigop(src.OpKind, src.Token);
        }
    }
}