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
        public readonly struct m8 : IMemOpClass<m8>, IAsmSigOp<m8, MemToken>
        {
            public MemToken Token => MemToken.m8;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W8;

            [MethodImpl(Inline)]
            public static implicit operator mem(m8 src)
                => new mem(src.Size);


            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m8 src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}