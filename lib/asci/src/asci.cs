//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct Asci
    {
        static AsciSymbols AsciStrings => default;
        [MethodImpl(Inline)]
        static int IndexLength(int i, int max)
            => found(i) ? i : max;
    }
}