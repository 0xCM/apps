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

    partial struct SpanRes
    {
       public Index<ByteSpanSpec> names<K>(Symbols<K> src)
            where K : unmanaged
        {
            var view = src.View;
            var count = view.Length;
            var buffer = alloc<ByteSpanSpec>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var sym = ref skip(view,i);
                seek(dst,i) = name(sym);
            }
            return buffer;
        }

        public ByteSpanSpec name<K>(Sym<K> src)
            where K : unmanaged
                => SpanRes.specify(src.Name, text.utf16(src.Name).ToArray());
    }
}