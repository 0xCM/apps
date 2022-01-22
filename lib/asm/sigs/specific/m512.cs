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
        public readonly struct m512 : IMemOpClass<m512>, IAsmSigOp<m512, MemToken>
        {
            public MemToken Token => MemToken.m512;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W512;

            [MethodImpl(Inline)]
            public static implicit operator Mem(m512 src)
                => new Mem(src.Token);

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m512 src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}