//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        public static string Format(this ReadOnlySpan<BitChar> src)
            => BitChars.format(src);

        public static string Format(this Span<BitChar> src)
            => BitChars.format(src);

    }
}