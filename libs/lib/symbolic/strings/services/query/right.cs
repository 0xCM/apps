//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> right(ReadOnlySpan<char> src, int index)
            => text.right(src,index);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> right(ReadOnlySpan<AsciCode> src, int index)
        {
            if(index < src.Length - 1)
                return slice(src, index + 1);
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> right(ReadOnlySpan<AsciSymbol> src, int index)
        {
            if(index < src.Length - 1)
                return slice(src, index + 1);
            else
                return default;
        }
    }
}