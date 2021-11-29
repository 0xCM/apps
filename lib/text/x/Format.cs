//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XText
    {
        [TextUtility]
        public static string Format(this ReadOnlySpan<char> src)
            => new string(src);

        [TextUtility]
        public static string Format(this Span<char> src)
            => new string(src);
    }
}