//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> before(ReadOnlySpan<char> src, char match)
        {
            var i = src.IndexOf(match);
            return i == NotFound ? default : core.slice(src,0,i);
        }
    }
}