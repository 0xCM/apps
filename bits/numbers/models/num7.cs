//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using T = num7;
    using D = System.Byte;
    using N = N7;

    [DataWidth(Width), ApiComplete]
    public readonly struct num7 : inum<T>
    {
        public readonly D Value;

        [MethodImpl(Inline)]
        public num7(D src)
            => Value = crop(src);

        [MethodImpl(Inline)]
        num7(ulong src)
            => Value = (D)src;

        /// <summary>
        /// 127
        /// </summary>
        public const byte Width = 7;

        public const D MaxValue = Pow2.T07m1;

        public const D Mod = (D)MaxValue + 1;

        public static T Zero => default;

        public static T One => cover(1);

        public static T Min => cover(0);

        public static T Max => cover(MaxValue);

        public static N N => default;

        [MethodImpl(Inline)]
        public static D crop(D src)
            => (D)(MaxValue & src);

        [MethodImpl(Inline)]
        public static T create(ulong src)
            => new T((D)src);

        [MethodImpl(Inline)]
        public static T cover(D src)
            => new T((uint)src);

        [MethodImpl(Inline)]
        public static T force<A>(A src)
            where A : unmanaged
                => T.crop(bw8(src));

        [MethodImpl(Inline)]
        public static bit test(T src, byte pos)
            => bit.test(src.Value, pos);

        [MethodImpl(Inline)]
        public static T set(T src, byte pos, bit state)
            => math.lt(pos, Width) ? cover(bit.set(src.Value, pos, state)) : src;

        [MethodImpl(Inline)]
        public static bit eq(T a, T b)
            => a.Value == b.Value;

        [MethodImpl(Inline)]
        public static bit ne(T a, T b)
            => a.Value != b.Value;

        [MethodImpl(Inline)]
        public static bit gt(T a, T b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bit ge(T a, T b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bit lt(T a, T b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bit le(T a, T b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static T negate(T src)
            => create(math.negate(src.Value));

        [MethodImpl(Inline)]
        public static T invert(T src)
           => cover((D)(math.and(math.not(src.Value), MaxValue)));

        [MethodImpl(Inline)]
        public static T or(T a, T b)
            => cover((D)(a.Value | b.Value));

        [MethodImpl(Inline)]
        public static T and(T a, T b)
            => cover((D)(a.Value & b.Value));

        [MethodImpl(Inline)]
        public static T xor(T a, T b)
            => cover((D)(a.Value ^ b.Value));

        [MethodImpl(Inline)]
        public static T srl(T src, byte count)
            => cover((D)(src.Value >> count));

        [MethodImpl(Inline)]
        public static T sll(T src, byte count)
            => cover((D)(src.Value << count));

        [MethodImpl(Inline)]
        public static T inc(T src)
            => src.Value != MaxValue ? cover(math.inc(src.Value)) : Min;

        [MethodImpl(Inline)]
        public static T dec(T src)
            => src.Value != 0 ? cover(math.dec(src.Value)) : Max;

        [MethodImpl(Inline)]
        public static T reduce(T src)
            => cover(math.mod(src.Value, Mod));

        [MethodImpl(Inline)]
        public static T add(T a, T b)
        {
            var c = math.add(a.Value, b.Value);
            return cover(math.gteq(c, Mod) ? math.sub(c, Mod) : c);
        }

        [MethodImpl(Inline)]
        public static T sub(T a, T b)
        {
            var c = math.sub((int)a.Value, (int)b.Value);
            return cover(c < 0 ? math.add((D)c, Mod) : (D)c);
        }

        [MethodImpl(Inline)]
        public static T mul(T a, T b)
            => reduce(math.mul(a.Value, b.Value));

        [MethodImpl(Inline)]
        public static T div(T a, T b)
            => cover(math.div(a.Value, b.Value));

        [MethodImpl(Inline)]
        public static T mod(T a, T b)
            => cover(math.mod(a.Value, b.Value));

        [MethodImpl(Inline)]
        public static string bitstring(T src)
            => BitRender.format(N, src.Value);

        [Parser]
        public static bool parse(string src, out T dst)
        {
            var outcome = byte.TryParse(src, out D x);
            dst = new T((D)(x & MaxValue));
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out T dst)
        {
            var result = byte.TryParse(src, out D x);
            dst = new T((D)(x & MaxValue));
            return result;
        }

        [MethodImpl(Inline)]
        public static ref Span<bit> bits(T src, out Span<bit> dst)
        {
            var storage = 0ul;
            dst = recover<bit>(@bytes(storage));
            Bitfields.unpack8x1(src,dst);
            dst = slice(dst, 0, Width);
            return ref dst;
        }

        byte inum.PackedWidth
            => Width;

        ulong inum.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => Value == src.Value;

        public bit IsZero
        {
             [MethodImpl(Inline)]
             get => Value == 0;
        }

        public bit IsNonZero
        {
             [MethodImpl(Inline)]
             get => Value != 0;
        }

        public bit IsMax
        {
            [MethodImpl(Inline)]
            get => Value == MaxValue;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(T src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => (int)Value;

        public override bool Equals(object src)
            => src is T t && Equals(t);

        [MethodImpl(Inline)]
        public static implicit operator T(D src)
            => new T(src);

        [MethodImpl(Inline)]
        public static implicit operator D(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(T src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ulong(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator T(ushort src)
            => create((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator T(uint src)
            => create((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator T(ulong src)
            => create((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator bit(T src)
            => (bit)(src.Value);

        [MethodImpl(Inline)]
        public static explicit operator num2(T src)
            => (num2)(src.Value);

        [MethodImpl(Inline)]
        public static explicit operator num3(T src)
            => (num3)(src.Value);

        [MethodImpl(Inline)]
        public static explicit operator num4(T src)
            => (num4)(src.Value);

        [MethodImpl(Inline)]
        public static explicit operator num5(T src)
            => (num5)(src.Value);

        [MethodImpl(Inline)]
        public static explicit operator num6(T src)
            => (num6)(src.Value);

        [MethodImpl(Inline)]
        public static T operator + (T x, T y)
            => add(x,y);

        [MethodImpl(Inline)]
        public static T operator - (T x, T y)
            => sub(x,y);

        [MethodImpl(Inline)]
        public static T operator * (T x, T y)
            => mul(x,y);

        [MethodImpl(Inline)]
        public static T operator / (T x, T y)
            => div(x,y);

        [MethodImpl(Inline)]
        public static T operator % (T x, T y)
            => mod(x,y);

        [MethodImpl(Inline)]
        public static T operator &(T x, T y)
            => and(x,y);

        [MethodImpl(Inline)]
        public static T operator |(T x, T y)
            => or(x,y);

        [MethodImpl(Inline)]
        public static T operator ^(T a, T b)
            => xor(a,b);

        [MethodImpl(Inline)]
        public static T operator >>(T x, int count)
            => srl(x, (byte)count);

        [MethodImpl(Inline)]
        public static T operator <<(T x, int count)
            => sll(x, (byte)count);

        [MethodImpl(Inline)]
        public static T operator ~(T src)
            => invert(src);

        [MethodImpl(Inline)]
        public static T operator -(T src)
            => negate(src);

        [MethodImpl(Inline)]
        public static T operator ++(T x)
            => inc(x);

        [MethodImpl(Inline)]
        public static T operator --(T x)
            => dec(x);

        [MethodImpl(Inline)]
        public static bit operator ==(T a, T b)
            => eq(a,b);

        [MethodImpl(Inline)]
        public static bit operator !=(T a, T b)
            => ne(a,b);

        [MethodImpl(Inline)]
        public static bit operator < (T a, T b)
            => lt(a,b);

        [MethodImpl(Inline)]
        public static bit operator <= (T a, T b)
            => le(a,b);

        [MethodImpl(Inline)]
        public static bit operator > (T a, T b)
            => gt(a,b);

        [MethodImpl(Inline)]
        public static bit operator >= (T a, T b)
            => ge(a,b);
    }
}