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

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> left(ReadOnlySpan<char> src, int index)
        {
            if(index < src.Length)
                return core.slice(src, 0, index);
            else
                return default;
        }

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