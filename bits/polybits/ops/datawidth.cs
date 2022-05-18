//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        public static byte datawidth(in asci64 src)
            => (byte)text.remove(src, Chars.Space).Length;
    }
}