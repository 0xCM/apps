//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMasks;
    using static math;

    [ApiHost]
    public readonly partial struct Numbers
    {
        internal const NumericKind Closure = UnsignedInts;

        internal const NumericKind Closure8 = NumericKind.U8;

        internal const NumericKind Closure16 = NumericKind.U16;

        internal const NumericKind Closure32 = NumericKind.U32;

        [MethodImpl(Inline), Op]
        public static num2 pack(bit a, bit b)
            => (num2)((uint)a | (uint)b << 1);

        [MethodImpl(Inline)]
        public static ref num4 read(ReadOnlySpan<byte> src, uint index, out num4 dst)
        {
            var cell = ScaledIndex.define(4, -2, index);
            ref readonly var b = ref skip(src, cell.Offset);
            dst = cell.Aligned ? num(n4,b) : num(n4, srl(b , (byte)cell.CellWidth));
            return ref dst;
        }

        [MethodImpl(Inline)]
        public static void write(num4 src, uint index, Span<byte> dst)
        {
            const byte UpperMask = 0xF0;
            const byte LowerMask = 0x0F;
            var cell = ScaledIndex.define(4, -2, index);
            ref var c = ref seek(dst, cell.Offset);
            if(cell.Aligned)
                c = or(and(c, UpperMask), src);
            else
                c = or(sll(src, (byte)cell.CellWidth), and(c, LowerMask));
        }

        [MethodImpl(Inline), Op]
        public static ulong max(byte width)
            => (ulong)Pow2.m1(width);

        /// <summary>
        /// Specifes the number of values covered by an <typeparamref name='N'>-bit number
        /// </summary>
        /// <param name="n">The natural bit width</param>
        /// <typeparam name="N">The natural with type</typeparam>
        [MethodImpl(Inline)]
        public static uint count<N>(N n)
            where N : unmanaged, ITypeNat
                => (uint)Pow2.pow((byte)n.NatValue);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num2 num<T>(N2 n, T src)
            where T : unmanaged
                => (num2)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num3 num<T>(N3 n, T src)
            where T : unmanaged
                => (num3)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num4 num<T>(N4 n, T src)
            where T : unmanaged
                => (num4)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num5 num<T>(N5 n, T src)
            where T : unmanaged
                => (num5)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num6 num<T>(N6 n, T src)
            where T : unmanaged
                => (num6)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num7 num<T>(N7 n, T src)
            where T : unmanaged
                => (num7)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num8 num<T>(N8 n, T src)
            where T : unmanaged
                => (num8)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num9 num<T>(N9 n, T src)
            where T : unmanaged
                => (num9)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num10 num<T>(N10 n, T src)
            where T : unmanaged
                => (num10)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num11 num<T>(N11 n, T src)
            where T : unmanaged
                => (num11)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num12 num<T>(N12 n, T src)
            where T : unmanaged
                => (num12)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num13 num<T>(N13 n, T src)
            where T : unmanaged
                => (num13)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num14 num<T>(N14 n, T src)
            where T : unmanaged
                => (num14)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num15 num<T>(N15 n, T src)
            where T : unmanaged
                => (num15)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num16 num<T>(N16 n, T src)
            where T : unmanaged
                => (num16)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num17 num<T>(N17 n, T src)
            where T : unmanaged
                => (num17)u32(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num32 num<T>(N32 n, T src)
            where T : unmanaged
                => (num32)u32(src);
    }
}