//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    using System;
    using System.Runtime.CompilerServices;

    partial struct seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqEditor<T> editor<T>(T* pSrc, long count)
            where T : unmanaged
                => new SeqEditor<T>(pSrc, count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe SeqEditor<T> editor<T>(NativeBuffer<T> src)
            where T : unmanaged
                => new SeqEditor<T>(gptr(first(src.Edit)), src.Count);
    }
}