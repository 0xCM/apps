//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => core.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);
    }
}