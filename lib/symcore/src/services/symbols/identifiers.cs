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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint identifiers<E>(Symbols<E> src, Span<string> dst)
            where E : unmanaged
        {
            var view = src.View;
            var count = (uint)min(view.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(view,i).Name;

            return count;
        }
    }
}