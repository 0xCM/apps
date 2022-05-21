//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMasks;

    [ApiHost]
    public readonly partial struct Numbers
    {
        internal const NumericKind Closure = UnsignedInts;

        internal const NumericKind Closure8 = NumericKind.U8;

        internal const NumericKind Closure16 = NumericKind.U16;

        internal const NumericKind Closure32 = NumericKind.U32;

        /// <summary>
        /// Partitions the source into 8 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x1(byte src, Span<byte> dst)
            => unpack1x8(src, ref first(dst));

        /// <summary>
        /// Partitions the source into 8 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x1(byte src, Span<bit> dst)
            => unpack1x8(src, ref u8(first(dst)));

        /// <summary>
        /// Distributes each packed source bit to the least significant bit of 8 corresponding target bytes
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">A reference to the target buffer</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack1x8(byte src, ref byte dst)
        {
            seek64(dst, 0) = bits.scatter(src, lsb<ulong>(n8,n1));
            return ref dst;
        }

        /// <summary>
        /// Distributes the first 4 source bits acros 4 segments, each of effective width of 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x1(byte src, Span<bit> dst)
            => first(recover<bit,uint>(dst)) = bits.scatter((uint)src, lsb<uint>(n8, n1));

        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(ushort src, Span<byte> dst)
        {
            var mask = BitMasks.lsb<ulong>(n8, n1);
            ref var lead = ref first(dst);
            seek64(lead, 0) = bits.scatter((ulong)(byte)src, mask);
            seek64(lead, 1) = bits.scatter((ulong)((byte)(src >> 8)), mask);
        }

        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(ushort src, Span<bit> dst)
            => unpack16x1(src, recover<bit,byte>(dst));

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

        /// <summary>
        /// Allocates and populates a character span, comprising each value covered by an <typeparamref name='N'>-bit number, expressed as a bitstring of length <typeparamref name='N'>
        /// </summary>
        /// <param name="n">The natural bit width</param>
        /// <typeparam name="N">The natural with type</typeparam>
        public static Span<char> bitstrings<N>(N n)
            where N : unmanaged, ITypeNat
        {
            var width = (uint)n.NatValue;
            var count = Numbers.count(n);
            var buffer = span<char>(count*width);
            for(var i=0; i<count; i++)
            {
                ref var c = ref seek(buffer,i*width);
                for(byte j=0; j<width; j++)
                    seek(c,width-1-j) = bit.test(i,(byte)j).ToChar();
            }
            return buffer;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T inc<T>(T src)
            where T : unmanaged
                => gmath.inc(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T dec<T>(T src)
            where T : unmanaged
                => gmath.dec(src);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static num<T> generic<T>(T value)
            where T : unmanaged
                => new num<T>(value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num<T> zero<T>()
            where T : unmanaged
                => new num<T>(core.zero<T>());

        [MethodImpl(Inline), One, Closures(Closure)]
        public static num<T> one<T>()
            where T : unmanaged
                => new num<T>(core.one<T>());

        [MethodImpl(Inline), Ones, Closures(Closure)]
        public static num<T> ones<T>()
            where T : unmanaged
                => new num<T>(core.ones<T>());

        [MethodImpl(Inline), Add, Closures(Closure)]
        public static num<T> add<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.add(a.Value, b.Value));

        [MethodImpl(Inline), Mul, Closures(Closure)]
        public static num<T> mul<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.mul(a.Value, b.Value));

        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static num<T> sub<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.sub(a.Value, b.Value));

        [MethodImpl(Inline), Div, Closures(Closure)]
        public static num<T> div<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.div(a.Value, b.Value));

        [MethodImpl(Inline), Mod, Closures(Closure)]
        public static num<T> mod<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.mod(a.Value, b.Value));

        [MethodImpl(Inline), Negate, Closures(Closure)]
        public static num<T> negate<T>(num<T> a)
            where T : unmanaged
                => generic(gmath.negate(a.Value));

        [MethodImpl(Inline), And, Closures(Integers)]
        public static num<T> and<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.and(a.Value, b.Value));

        [MethodImpl(Inline), Or, Closures(Integers)]
        public static num<T> or<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.or(a.Value, b.Value));

        [MethodImpl(Inline), Xor, Closures(Integers)]
        public static num<T> xor<T>(num<T> a, num<T> b)
            where T : unmanaged
                => generic(gmath.xor(a.Value, b.Value));

        [MethodImpl(Inline), Not, Closures(Integers)]
        public static num<T> not<T>(num<T> a)
            where T : unmanaged
                => generic(gmath.not(a.Value));

        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static num<T> sll<T>(num<T> a, byte offset)
            where T : unmanaged
                => generic(gmath.sll(a.Value, offset));

        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static num<T> srl<T>(num<T> a, byte offset)
            where T : unmanaged
                => generic(gmath.srl(a.Value, offset));

        [MethodImpl(Inline), Eq, Closures(Closure)]
        public static bit eq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.eq(a.Value,b.Value);

        [MethodImpl(Inline), Neq, Closures(Closure)]
        public static bit neq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.neq(a.Value,b.Value);

        [MethodImpl(Inline), Lt, Closures(Closure)]
        public static bit lt<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.lt(a.Value,b.Value);

        [MethodImpl(Inline), Gt, Closures(Closure)]
        public static bit gt<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.gt(a.Value,b.Value);

        [MethodImpl(Inline), LtEq, Closures(Closure)]
        public static bit lteq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.lteq(a.Value,b.Value);

        [MethodImpl(Inline), GtEq, Closures(Closure)]
        public static bit gteq<T>(num<T> a, num<T> b)
            where T : unmanaged
                => gmath.gteq(a.Value,b.Value);

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