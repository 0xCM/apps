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

    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static void convert(in AsciLine src, Span<char> buffer, out UnicodeLine dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(buffer, i) = (char)skip(src.Codes,i);
            dst = new UnicodeLine(src.LineNumber, text.format(buffer));
        }
    }
}