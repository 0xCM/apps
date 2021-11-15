//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> left(ReadOnlySpan<char> src, int index)
        {
            if(index < src.Length)
                return slice(src, 0, index);
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> left(ReadOnlySpan<AsciCode> src, int index)
        {
            if(index < src.Length)
                return slice(src, 0, index);
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> left(ReadOnlySpan<AsciSymbol> src, int index)
        {
            if(index < src.Length)
                return slice(src, 0, index);
            else
                return default;
        }
    }
}