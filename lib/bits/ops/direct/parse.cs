//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        public static int parse(string src, Span<bit> dst)
            => bit.parse(src, dst);
    }
}