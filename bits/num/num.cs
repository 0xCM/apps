//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct num
    {
        const NumericKind Closure = AllNumeric;

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
            var count = num.count(n);
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
        public static num2 Num2<T>(T src)
            where T : unmanaged
                => (num2)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num3 Num3<T>(T src)
            where T : unmanaged
                => (num3)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num4 Num4<T>(T src)
            where T : unmanaged
                => (num4)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num5 Num5<T>(T src)
            where T : unmanaged
                => (num5)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num6 Num6<T>(T src)
            where T : unmanaged
                => (num6)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num7 Num7<T>(T src)
            where T : unmanaged
                => (num7)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num8 Num8<T>(T src)
            where T : unmanaged
                => (num8)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num9 Num9<T>(T src)
            where T : unmanaged
                => (num9)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num2 Num<T>(N2 n, T src)
            where T : unmanaged
                => (num2)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num3 Num<T>(N3 n, T src)
            where T : unmanaged
                => (num3)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num4 Num<T>(N4 n, T src)
            where T : unmanaged
                => (num4)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num5 Num<T>(N5 n, T src)
            where T : unmanaged
                => (num5)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num6 Num<T>(N6 n, T src)
            where T : unmanaged
                => (num6)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num7 Num<T>(N7 n, T src)
            where T : unmanaged
                => (num7)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num8 Num<T>(N8 n, T src)
            where T : unmanaged
                => (num8)u8(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num9 Num<T>(N9 n, T src)
            where T : unmanaged
                => (num9)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num10 Num<T>(N10 n, T src)
            where T : unmanaged
                => (num10)u16(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static num11 Num<T>(N11 n, T src)
            where T : unmanaged
                => (num11)u16(src);
    }
}