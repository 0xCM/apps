//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> left(ReadOnlySpan<char> src, int index)
            => text.left(src,index);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> left(ReadOnlySpan<C> src, int index)
        {
            if(index < src.Length)
                return slice(src, 0, index);
            else
                return default;
        }
    }
}