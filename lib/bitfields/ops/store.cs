//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static ref Bitfield8 store(byte src, byte offset, byte width, ref Bitfield8 dst)
        {
            dst.Overwrite(math.or(dst.State, math.sll(src, width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Bitfield16 store(ushort src, byte offset, byte width, ref Bitfield16 dst)
        {
            dst.Overwrite(math.or(dst.State, math.sll(src, width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Bitfield32 store(uint src, byte offset, byte width, ref Bitfield32 dst)
        {
            dst.Overwrite(math.or(dst.State, math.sll(src, width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Bitfield64 store(ulong src, byte offset, byte width, ref Bitfield64 dst)
        {
            dst.Overwrite(math.or(dst.State, math.sll(src, width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(UInt8k)]
        public static ref Bitfield8<T> store<T>(T src, byte offset, byte width, ref Bitfield8<T> dst)
            where T : unmanaged
        {
            dst.Overwrite(math.or(dst.State, math.sll(u8(src), width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static ref Bitfield16<T> store<T>(T src, byte offset, byte width, ref Bitfield16<T> dst)
            where T : unmanaged
        {
            dst.Overwrite(math.or(dst.State, math.sll(u16(src), width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static ref Bitfield32<T> store<T>(T src, byte offset, byte width, ref Bitfield32<T> dst)
            where T : unmanaged
        {
            dst.Overwrite(math.or(dst.State, math.sll(u32(src), width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static ref Bitfield64<T> store<T>(T src, byte offset, byte width, ref Bitfield64<T> dst)
            where T : unmanaged
        {
            dst.Overwrite(math.or(dst.State, math.sll(u64(src), width)));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Bitfield<T> store<T>(T src, byte i, ref Bitfield<T> dst)
            where T : unmanaged
        {
            ref readonly var spec = ref skip(dst.SegSpecs,i);
            dst.Overwrite(gmath.or(dst.State, gmath.sll(dst.State, u8(spec.SegWidth))));
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static ref Bitfield<T,K> store<T,K>(T src, byte i, ref Bitfield<T,K> dst)
            where T : unmanaged
            where K : unmanaged
        {
            ref readonly var spec = ref skip(dst.SegSpecs,i);
            dst.Overwrite(gmath.or(dst.State, gmath.sll(dst.State, u8(spec.SegWidth))));
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(T src, byte index, ref Bitfield256<T> dst)
            where T : unmanaged
                => dst.State = cpu.vcell(dst.State, index, gmath.and(src, dst.Mask(index)));

        [MethodImpl(Inline)]
        public static void store<E,T>(T src, E index, ref Bitfield256<E,T> dst)
            where E : unmanaged
            where T : unmanaged
                => dst.State = cpu.vcell(dst.State, bw8(index), gmath.and(src, dst.Mask(index)));
   }
}