//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmLine
    {
        public Index<object> Tokens {get;}

        [MethodImpl(Inline), Op]
        public AsmLine(Index<object> src)
        {
            Tokens = src;
        }

        public string Format()
            => string.Concat(Tokens.Select(x => x.ToString()));
    }
}