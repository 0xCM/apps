//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Flags
    {
        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static bit state<E>(Flags8<E> src, Pow2x8 flag)
            where E : unmanaged
                => (bw8(src.State) & bw8(flag)) != 0;

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static ref Flags8<E> enable<E>(byte pos, ref Flags8<E> dst)
            where E : unmanaged
        {
            dst.Update(@as<byte,E>(bit.enable(bw8(dst.State),pos)));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k)]
        public static bit state<E>(Flags16<E> src, Pow2x16 flag)
            where E : unmanaged
                => (bw16(src.State) & bw16(flag)) != 0;

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k | UInt32k)]
        public static bit state<E>(Flags32<E> src, Pow2x32 flag)
            where E : unmanaged
                => (bw32(src.State) & bw32(flag)) != 0;

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static bit state<E>(Flags64<E> src, Pow2x64 flag)
            where E : unmanaged
                => (bw64(src.State) & bw64(flag)) != 0;

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static bit state<E>(Flags8<E> src, byte index)
            where E : unmanaged
                => bit.test(u8(src.State), index);

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k)]
        public static bit state<E>(Flags16<E> src, byte index)
            where E : unmanaged
                => bit.test(u16(src.State), index);

        [MethodImpl(Inline), Op, Closures(UInt8k | UInt16k | UInt32k)]
        public static bit state<E>(Flags32<E> src, byte index)
            where E : unmanaged
                => bit.test(u32(src.State), index);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static bit state<E>(Flags64<E> src, byte index)
            where E : unmanaged
                => bit.test(u64(src.State), index);

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static bit state<T>(Flags<T> src, byte index)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return bit.test(u8(src.State), index);
            else if(size<T>() == 2)
                return bit.test(u16(src.State), index);
            else if(size<T>() == 4)
                return bit.test(u32(src.State), index);
            else
                return bit.test(u64(src.State), index);
        }
    }
}