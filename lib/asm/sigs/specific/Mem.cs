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
            public MemToken Token {get;}

            public AsmSigOpKind Kind => AsmSigOpKind.Mem;

            [MethodImpl(Inline)]
            public mem(MemToken token)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(mem src)
                => asm.sigop(src.Kind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator mem(MemToken src)
                => new mem(src);
        }
    }
}