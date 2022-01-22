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
        public readonly struct m256 : IMemOpClass<m256>, IAsmSigOp<m256, MemToken>
        {
            public MemToken Token => MemToken.m256;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;
            public AsmOpClass OpClass
                => AsmOpClass.Mem;
            public NativeSize Size
                => NativeSizeCode.W256;

            [MethodImpl(Inline)]
            public static implicit operator Mem(m256 src)
                => new Mem(src.Token);


            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(m256 src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}