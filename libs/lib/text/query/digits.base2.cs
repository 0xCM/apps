//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        [MethodImpl(Inline)]
        public static uint digits(Base2 @base, ReadOnlySpan<char> src, uint offset, Span<char> dst)
            => Digital.digits(@base, src, offset, dst);

        [MethodImpl(Inline)]
        public static uint digits(Base2 @base, ReadOnlySpan<char> src, Span<char> dst)
            => Digital.digits(@base, src, dst);
    }
}