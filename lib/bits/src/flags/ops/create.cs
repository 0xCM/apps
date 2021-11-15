//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Flags
    {
        [MethodImpl(Inline), Op]
        public static Flags<Pow2x3> create(Pow2x3 src)
            => new Flags<Pow2x3>(src);

        [MethodImpl(Inline), Op]
        public static Flags<Pow2x4> create(Pow2x4 src)
            => new Flags<Pow2x4>(src);

        [MethodImpl(Inline), Op]
        public static Flags<Pow2x8> create(Pow2x8 src)
            => new Flags<Pow2x8>(src);

        [MethodImpl(Inline), Op]
        public static Flags<Pow2x16> create(Pow2x16 e)
            => new Flags<Pow2x16>(e);

        [MethodImpl(Inline), Op]
        public static Flags<Pow2x32> create(Pow2x32 e)
            => new Flags<Pow2x32>(e);

        [MethodImpl(Inline), Op]
        public static Flags<Pow2x64> create(Pow2x64 e)
            => new Flags<Pow2x64>(e);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static Flags8<E> create<E>(W8 w, E e)
            where E : unmanaged
                => new Flags8<E>(e);

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k)]
        public static Flags16<E> create<E>(W16 w, E e)
            where E : unmanaged
                => new Flags16<E>(e);

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k | UInt32k)]
        public static Flags32<E> create<E>(W32 w, E e)
            where E : unmanaged
                => new Flags32<E>(e);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Flags64<E> create<E>(W64 w, E e)
            where E : unmanaged
                => new Flags64<E>(e);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static Flags8<K> flags8<K>(K state)
            where K : unmanaged
                => new Flags8<K>(state);

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k)]
        public static Flags16<K> flags16<K>(K state)
            where K : unmanaged
                => new Flags16<K>(state);

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k | UInt32k)]
        public static Flags32<K> flags32<K>(K state)
            where K : unmanaged
                => new Flags32<K>(state);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Flags64<K> flags64<K>(K state)
            where K : unmanaged
                => new Flags64<K>(state);
    }
}
