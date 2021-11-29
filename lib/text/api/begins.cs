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
        public static bool begins(string src, char match)
            => length(src) != 0 && @char(src) == match;

        [MethodImpl(Inline), Op]
        public static bool begins(string src, string match)
            => length(src) != 0 && src.StartsWith(match);
    }
}