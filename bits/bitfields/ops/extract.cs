//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T>(T src, byte offset, byte width)
            where T : unmanaged
                => generic<T>(bits.extract(@bw64(src), offset, math.add(offset, width)));

        [MethodImpl(Inline)]
        public static T extract<F,T>(BitfieldDataset<F,T> bitfield, F field, T src)
            where F : unmanaged, Enum
            where T : unmanaged
                => extract(src, bitfield.Offset(field), bitfield.Width(field));

        [MethodImpl(Inline), Op]
        public static byte extract(Bitfield8 src, byte min, byte max)
            => bits.extract(src.State, min, max);

        [MethodImpl(Inline), Op]
        public static ushort extract(Bitfield16 src, byte min, byte max)
            => bits.extract(src.State, min, max);

        [MethodImpl(Inline), Op]
        public static uint extract(Bitfield32 src, byte min, byte max)
            => bits.extract(src.State, min, max);

        [MethodImpl(Inline), Op]
        public static ulong extract(Bitfield64 src, byte min, byte max)
            => bits.extract(src.State, min, max);

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static T extract<T>(Bitfield8<T> src, byte min, byte max)
            where T : unmanaged
                => @as<T>(bits.extract(src.State8u, min, max));

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static T extract<T>(Bitfield16<T> src, byte min, byte max)
            where T : unmanaged
                => @as<T>(bits.extract(src.State16u, min, max));

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static T extract<T>(Bitfield32<T> src, byte min, byte max)
            where T : unmanaged
                => @as<T>(bits.extract(src.State32u, min, max));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static T extract<T>(Bitfield64<T> src, byte min, byte max)
            where T : unmanaged
                => @as<T>(bits.extract(src.State, min, max));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T>(in Bitfield<T> src, byte i)
            where T : unmanaged
        {
            ref readonly var spec = ref skip(src.SegSpecs,i);
            return gbits.extract(src.State, (byte)spec.MinIndex, (byte)spec.MaxIndex);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T,K>(in Bitfield<T,K> src, byte i)
            where T : unmanaged
            where K : unmanaged
        {
            ref readonly var spec = ref skip(src.SegSpecs, i);
            return gbits.extract(src.State, (byte)spec.MinIndex, (byte)spec.MaxIndex);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T>(in Bitfield256<T> src, byte index)
            where T : unmanaged
                => gmath.and(cpu.vcell(src.State, index), src.Mask(index));

        [MethodImpl(Inline)]
        public static T extract<E,T>(in Bitfield256<E,T> src, E index)
            where E : unmanaged
            where T : unmanaged
                => gmath.and(cpu.vcell(src.State, bw8(index)), src.Mask(index));
    }
}