//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.Unsafe;
    using static Root;

    partial struct minicore
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(in T src, long count)
            => ref Add(ref As<T,long>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(in T src, ulong count)
            => ref Add(ref As<T,long>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,long>(ref edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long skip64i<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,long>(ref edit(first(src))), (int)count);
    }
}