//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiToken
    {
        public ulong Value {get;}

        [MethodImpl(Inline)]
        public ApiToken(ulong src)
        {
            Value = src;
        }

        public static ApiToken Empty => default;
    }
}