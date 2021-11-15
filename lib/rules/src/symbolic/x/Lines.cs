//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;


    partial class XTend
    {
        [TextUtility]
        public static ReadOnlySpan<TextLine> Lines(this string src, bool keepblank = false)
            => Z0.Lines.read(src, keepblank);
    }
}