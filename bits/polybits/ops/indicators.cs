//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static Index<string> indicators(in asci64 src)
            => text.split(src, Chars.Space).Reverse();
    }
}