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

    partial struct Symbols
    {
        public static Index<Label> names<E>()
            where E : unmanaged, Enum
        {
            var src = index<E>();
            var count = src.Count;
            var dst = alloc<Label>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref src[i];
                seek(dst,i) = s.Name.Content;
            }
            return dst;
        }

    }
}