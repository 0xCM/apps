//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using T = num16;
    using D = System.UInt16;
    using N = N16;

    [DataWidth(PackedWidth, NativeWidth), ApiComplete]
    public readonly struct num16 : inum<T>
    {
        public readonly D Value;

        [MethodImpl(Inline)]
        public num16(D src)
            => Value = crop(src);

        [MethodImpl(Inline)]
        num16(ulong src)
            => Value = (D)src;

        byte inum.Width
            => PackedWidth;

        ulong inum.Value
            => Value;

        public const byte PackedWidth = 16;

        public const byte NativeWidth = 16;

        public const D MaxValue = Pow2.T16m1;

        public const uint Mod = (D)MaxValue + 1;

        public static T Zero => default;

        public static T One => wrap(1);

        public static T Min => wrap(0);

        public static T Max => wrap(MaxValue);

        public static N N => default;

        [MethodImpl(Inline)]
        public static D crop(D src)
            => (D)(MaxValue & src);

        [MethodImpl(Inline)]
        public static T create(D src)
            => new T(src);

        [MethodImpl(Inline)]
        public static T create(ulong src)
            => new T((D)src);

        [MethodImpl(Inline)]
        public static T wrap(D src)
            => new T((uint)src);

        [MethodImpl(Inline), Op]
        public static bit test(T src, byte pos)
            => bit.test(src.Value, pos);

        [MethodImpl(Inline), Op]
        public static T set(T src, byte pos, bit state)
            => math.lt(pos, PackedWidth) ? wrap(bit.set(src.Value, pos, state)) : src;

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

        [MethodImpl(Inline), Op]
        public static T negate(T src)
            => create(math.negate(src.Value));

        [MethodImpl(Inline)]
        public static T invert(T src)
           => wrap((D)(math.and(math.not(src.Value), MaxValue)));

        [MethodImpl(Inline), Op]
        public static T or(T a, T b)
            => wrap((D)(a.Value | b.Value));

        [MethodImpl(Inline), Op]
        public static T and(T a, T b)
            => wrap((D)(a.Value & b.Value));

        [MethodImpl(Inline), Op]
        public static T xor(T a, T b)
            => wrap((D)(a.Value ^ b.Value));

        [MethodImpl(Inline), Op]
        public static T srl(T src, byte count)
            => wrap((D)(src.Value >> count));

        [MethodImpl(Inline), Op]
        public static T sll(T src, byte count)
            => wrap((D)(src.Value << count));

        [MethodImpl(Inline), Op]
        public static T inc(T src)
            => src.Value != MaxValue ? wrap(math.inc(src.Value)) : Min;

        [MethodImpl(Inline), Op]
        public static T dec(T src)
            => src.Value != 0 ? wrap(math.dec(src.Value)) : Max;

        [MethodImpl(Inline), Op]
        public static T reduce(T src)
            => wrap((ushort)(math.mod(src.Value, Mod)));

        [MethodImpl(Inline), Op]
        public static T add(T a, T b)
        {
            var c = math.add(a.Value, b.Value);
            return wrap((ushort)(math.gteq(c, Mod) ? math.sub(c, Mod) : c));
        }

        [MethodImpl(Inline), Op]
        public static T sub(T a, T b)
        {
            var c = math.sub((int)a.Value, (int)b.Value);
            return wrap((ushort)(c < 0 ? math.add((D)c, Mod) : (D)c));
        }

        [MethodImpl(Inline), Op]
        public static T mul(T a, T b)
            => reduce(math.mul(a.Value, b.Value));

        [MethodImpl(Inline), Op]
        public static T div(T a, T b)
            => wrap(math.div(a.Value, b.Value));

        [MethodImpl(Inline)]
        public static T mod(T a, T b)
            => wrap(math.mod(a.Value, b.Value));

        [Parser]
        public static bool parse(string src, out T dst)
        {
            var outcome = D.TryParse(src, out D x);
            dst = new T((D)(x & MaxValue));
            return outcome;
        }

        [Parser]
        public static bool parse(ReadOnlySpan<char> src, out T dst)
        {
            var result = D.TryParse(src, out D x);
            dst = new T((D)(x & MaxValue));
            return result;
        }

        [MethodImpl(Inline), Op]
        public static ref Span<bit> bits(T src, out Span<bit> dst)
        {
            var storage = ByteBlock16.Empty;
            dst = recover<bit>(storage.Bytes);
            Bitfields.unpack16x1(src, dst);
            dst = slice(dst, 0, PackedWidth);
            return ref dst;
        }

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => eq(this, src);

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
        public static implicit operator T(byte src)
            => create(src);

        [MethodImpl(Inline)]
        public static explicit operator byte(T src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(sbyte src)
            => create((ushort)src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(T src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ushort(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(ushort src)
            => new T(src);

        [MethodImpl(Inline)]
        public static implicit operator T(short src)
            => wrap((ushort)src);

        [MethodImpl(Inline)]
        public static implicit operator uint(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator T(uint src)
            => create(src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(T src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator T(ulong src)
            => create((ushort)src);

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