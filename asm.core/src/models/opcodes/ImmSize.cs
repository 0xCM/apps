//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOpCodeTokens;

    public readonly struct ImmSize
    {
        public ImmSizeToken Token {get;}

        [MethodImpl(Inline)]
        public ImmSize(ImmSizeToken src)
        {
            Token = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ImmSize(ImmSizeToken src)
            => new ImmSize(src);

        [MethodImpl(Inline)]
        public static implicit operator ImmSizeToken(ImmSize src)
            => src.Token;

        [MethodImpl(Inline)]
        public static explicit operator byte(ImmSize src)
            => (byte)src.Token;
    }
}