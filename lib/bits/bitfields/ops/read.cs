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

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static byte read(Bitfield8 src, byte pos, byte width)
            => bits.slice(src.State, pos, width);

        [MethodImpl(Inline), Op]
        public static ushort read(Bitfield16 src, byte i0, byte i1)
            => bits.slice(src.State, i0, i1);

        [MethodImpl(Inline), Op]
        public static uint read(Bitfield32 src, byte i0, byte i1)
            => bits.slice(src.State, i0, i1);

        [MethodImpl(Inline), Op]
        public static ulong read(Bitfield64 src, byte i0, byte i1)
            => bits.slice(src.State, i0, i1);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static T read<T>(Bitfield8<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.slice(src.State, i0, i1));

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static T read<T>(Bitfield16<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.slice(src.State, i0, i1));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static T read<T>(Bitfield32<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.slice(src.State, i0, i1));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T read<T>(Bitfield64<T> src, byte i0, byte i1)
            where T : unmanaged
                => @as<T>(bits.slice(src.State, i0, i1));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T read<T>(in Bitfield<T> src, byte i)
            where T : unmanaged
        {
            ref readonly var spec = ref skip(src.SegSpecs,i);
            return gbits.slice(src.State, (byte)spec.Offset, (byte)spec.Width);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T read<T,K>(in Bitfield<T,K> src, byte i)
            where T : unmanaged
            where K : unmanaged
        {
            ref readonly var spec = ref skip(src.SegSpecs,i);
            return gbits.slice(src.State, (byte)spec.Offset, (byte)spec.Width);
        }
    }
}