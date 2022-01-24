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
        public readonly struct Mem : IMemOpClass<Mem>, IAsmSigOp<Mem,MemToken>
        {
            public MemToken Token {get;}

            public AsmSigOpKind OpKind => AsmSigOpKind.Mem;

            [MethodImpl(Inline)]
            public Mem(MemToken token)
            {
                Token = token;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            [MethodImpl(Inline)]
            public static implicit operator AsmSigOp(Mem src)
                => asm.sigop(src.OpKind, src.Token);

            [MethodImpl(Inline)]
            public static implicit operator Mem(MemToken src)
                => new Mem(src);
        }
    }
}