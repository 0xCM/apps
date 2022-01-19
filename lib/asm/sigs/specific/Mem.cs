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
        public readonly struct mem : IMemOpClass<mem>, IAsmSigOp<mem, MemToken>
        {
            public MemToken Token => MemToken.mem;

            public NativeSize Size {get;}

            [MethodImpl(Inline)]
            public mem(NativeSize size)
            {
                Size = size;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(mem src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}