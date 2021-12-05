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

    partial struct bit
    {
        public static string format(ReadOnlySpan<bit> src)
        {
            var count = (int)src.Length;
            Span<char> buffer = stackalloc char[count];
            for(var i=0; i<count; i++)
                seek(buffer,i) = skip(src,i).ToChar();
            buffer.Reverse();
            return text.format(buffer);
        }
    }
}