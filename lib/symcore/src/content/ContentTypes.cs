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

    [ApiHost]
    public readonly struct ContentTypes
    {
        public static ReadOnlySpan<ContentType> known()
        {
            var symbols = Symbols.index<ContentKind>().View;
            var count = symbols.Length;
            var buffer = alloc<ContentType>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                seek(dst,i) = new ContentType(symbol.Kind, symbol.Name.Content);
            }
            return buffer;
        }


        [MethodImpl(Inline), Op]
        public static ContentType define(ContentKind kind, string name)
            => new ContentType(kind,name);
    }
}