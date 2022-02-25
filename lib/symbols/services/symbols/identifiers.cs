//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Symbols
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint names<E>(Symbols<E> src, Span<Label> dst)
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