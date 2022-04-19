//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class TokenDispenser
    {
        static long StartToken;

        static long EndToken;

        public static TokenDispenser create()
            => new TokenDispenser();

        [MethodImpl(Inline)]
        public ExecToken Open()
            => new ExecToken((ulong)core.inc(ref StartToken));

        [MethodImpl(Inline)]
        public ExecToken Close(ExecToken src)
            => src.Complete((ulong)core.inc(ref EndToken));
    }
}