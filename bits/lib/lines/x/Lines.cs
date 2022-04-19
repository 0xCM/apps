//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        [TextUtility]
        public static ReadOnlySpan<TextLine> Lines(this string src, bool keepblank = false, bool trim = true)
            => Z0.Lines.read(src, keepblank, trim);
    }
}