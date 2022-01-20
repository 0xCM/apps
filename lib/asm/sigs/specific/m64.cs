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
        public readonly struct m64 : IMemOpClass<m64>, IAsmSigOp<m64, MemToken>
        {
            public MemToken Token => MemToken.m64;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W64;

            [MethodImpl(Inline)]
            public static implicit operator mem(m64 src)
                => new mem(src.Token);


            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m64 src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}