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
        public static ref readonly ushort skip16<T>(in T src, long count)
            => ref Add(ref As<T,ushort>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort skip16<T>(in T src, ulong count)
            => ref Add(ref As<T,ushort>(ref edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort skip16<T>(ReadOnlySpan<T> src, long count)
           => ref Add(ref As<T,ushort>(ref edit(first(src))), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort skip16<T>(ReadOnlySpan<T> src, ulong count)
           => ref Add(ref As<T,ushort>(ref edit(first(src))), (int)count);

        [MethodImpl(Inline)]
        public static ref readonly T skip16k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), u16(count));
     }
}