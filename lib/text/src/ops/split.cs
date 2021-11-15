//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class text
    {
        [Op]
        public static ReadOnlySpan<string> split(string src, char sep, bool clean = true)
            => src.Split(sep,  clean ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);

        [Op]
        public static ReadOnlySpan<string> split(string src, string sep, bool clean = true)
            => src.Split(sep, clean ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
    }
}