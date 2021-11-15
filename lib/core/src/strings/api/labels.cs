//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct strings
    {
        [Op]
        public static BufferedLabels labels(ReadOnlySpan<string> src)
        {
            var b = buffer(src, out var labels);
            return new BufferedLabels(b,labels);
        }
    }
}