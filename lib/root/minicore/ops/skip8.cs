//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct minicore
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(in T src, long count)
            => ref add(@as<T,byte>(edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(in T src, ulong count)
            => ref add(@as<T,byte>(edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(ReadOnlySpan<T> src, long count)
            => ref add(@as<T,byte>(first(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte skip8<T>(ReadOnlySpan<T> src, ulong count)
            => ref add(@as<T,byte>(first(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref readonly T skip8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref edit(src), u8(count));
    }
}