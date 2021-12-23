//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial struct SymbolicQuery
    {
        [Op]
        public static ClosedInterval<int> enclosed(ReadOnlySpan<char> src, int offset, Fence<char> fence)
            => text.enclosed(src,offset,fence);
    }
}