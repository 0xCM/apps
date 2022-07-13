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
        public static ref readonly uint skip32<T>(ReadOnlySpan<T> src, long count)
            => ref Add(ref As<T,uint>(ref Refs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint skip32<T>(ReadOnlySpan<T> src, ulong count)
            => ref Add(ref As<T,uint>(ref Refs.edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint seek32<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,uint>(ref first(src)), (int)count);
    }
}