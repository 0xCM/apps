//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static Bitfield8 create(byte state)
            => new Bitfield8(state);

        [MethodImpl(Inline), Op]
        public static Bitfield16 create(ushort state)
            => new Bitfield16(state);

        [MethodImpl(Inline), Op]
        public static Bitfield32 create(uint state)
            => new Bitfield32(state);

        [MethodImpl(Inline), Op]
        public static Bitfield64 create(ulong state)
            => new Bitfield64(state);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static Bitfield8<T> create<T>(W8 w, T state)
            where T : unmanaged
                => new Bitfield8<T>(state);

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static Bitfield16<T> create<T>(W16 w, T state)
            where T : unmanaged
                => new Bitfield16<T>(state);

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static Bitfield32<T> create<T>(W32 w, T state)
            where T : unmanaged
                => new Bitfield32<T>(state);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Bitfield64<T> create<T>(W64 w, T state)
            where T : unmanaged
                => new Bitfield64<T>(state);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Bitfield<T> create<T>(BitfieldSegModel[] segs, T state)
            where T : unmanaged
                => new Bitfield<T>(segs,state);

        [MethodImpl(Inline)]
        public static Bitfield<T,K> create<T,K>(BitfieldSegModel<K>[] segs, T state)
            where T : unmanaged
            where K : unmanaged
                => new Bitfield<T,K>(segs,state);
    }
}