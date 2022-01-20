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
        public readonly struct mem : IMemOpClass<mem>, IAsmSigOp<mem,MemToken>
        {
            public MemToken Token => MemToken.mem;

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            public NativeSize Size {get;}

            [MethodImpl(Inline)]
            public mem(NativeSize size)
            {
                Size = size;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(mem src)
                => asm.sigop(src.Kind, src.Token);
        }
    }
}