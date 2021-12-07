//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(string src)
            => src;
    }
}