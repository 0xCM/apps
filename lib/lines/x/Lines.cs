//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Text;

    partial class XText
    {
        [TextUtility]
        public static ReadOnlySpan<TextLine> Lines(this string src, bool keepblank = false)
            => Z0.Lines.read(src, keepblank);
    }
}