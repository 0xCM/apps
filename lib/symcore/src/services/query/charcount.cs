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
        public static uint charcount(ReadOnlySpan<string> src)
        {
            var counter = 0u;
            var count = src.Length;
            for(var i=0; i<counter; i++)
                counter += (uint)skip(src,i).Length;
            return counter;
        }
    }
}