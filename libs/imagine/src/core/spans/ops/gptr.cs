//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class Spans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* gptr<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => (T*)AsPointer(ref Refs.edit(first(src)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* gptr<T>(Span<T> src)
            where T : unmanaged
                => (T*)AsPointer(ref Refs.edit(first(src)));
    }
}