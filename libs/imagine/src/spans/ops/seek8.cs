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
        public static bool same<T>(in T a, in T b)
            => Unsafe.AreSame(ref Refs.edit(a), ref Refs.edit(b));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte seek8<T>(in T src, ulong count)
            => ref Refs.add(Refs.@as<T,byte>(Refs.edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte seek8<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,byte>(ref first(src)), (int)count);

        [MethodImpl(Inline)]
        public static ref T seek8k<T,K>(in T src, K count)
            where K : unmanaged
                => ref Add(ref Refs.edit(src), Refs.u8(count));
    }
}