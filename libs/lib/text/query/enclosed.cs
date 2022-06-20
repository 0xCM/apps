//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        [Op]
        public static ClosedInterval<int> enclosed(ReadOnlySpan<char> src, int offset, Fence<char> fence)
            => text.enclosed(src,offset,fence);
    }
}