//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct TextTools
    {
        [Op]
        public static string format(ReadOnlySpan<char> src)
            => new string(src);
    }
}