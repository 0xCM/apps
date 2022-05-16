//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct num<T> : IScalarValue<T>, IComparable<num<T>>, IEquatable<num<T>>
        where T : unmanaged
    {
        public T Value;

        public TypeSpec ScalarType
            => TypeSyntax.num(TypeSyntax.infer<T>());

        [MethodImpl(Inline)]
        public num(T value)
            => Value = value;

        [MethodImpl(Inline)]
        public bool Equals(num<T> src)
            => Numbers.eq(this, src);

        [MethodImpl(Inline)]
        public int CompareTo(num<T> src)
            => gmath.cmp(Value,src.Value);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value.ToString();

        public override bool Equals(object src)
            => src is num<T> x && Equals(x);

        T IValue<T>.Value
            => Value;

        BitWidth ISizedValue.ContentWidth
            => core.width<T>();

        [MethodImpl(Inline)]
        public static bool operator ==(num<T> a, num<T> b)
            => Numbers.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(num<T> a, num<T> b)
            => Numbers.neq(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(num<T> a, num<T> b)
            => Numbers.lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(num<T> a, num<T> b)
            => Numbers.gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <=(num<T> a, num<T> b)
            => Numbers.lteq(a,b);

        [MethodImpl(Inline)]
        public static bool operator >=(num<T> a, num<T> b)
            => Numbers.gteq(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator +(num<T> a, num<T> b)
            => Numbers.add(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator -(num<T> a, num<T> b)
            => Numbers.sub(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator *(num<T> a, num<T> b)
            => Numbers.mul(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator /(num<T> a, num<T> b)
            => Numbers.div(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator %(num<T> a, num<T> b)
            => Numbers.mod(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator -(num<T> a)
            => Numbers.negate(a);

        [MethodImpl(Inline)]
        public static num<T> operator &(num<T> a, num<T> b)
            => Numbers.and(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator |(num<T> a, num<T> b)
            => Numbers.or(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator ^(num<T> a, num<T> b)
            => Numbers.xor(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator >>(num<T> a, int offset)
            => Numbers.srl(a,(byte)offset);

        [MethodImpl(Inline)]
        public static num<T> operator <<(num<T> a, int offset)
            => Numbers.sll(a,(byte)offset);

        [MethodImpl(Inline)]
        public static num<T> operator ~(num<T> a)
            => Numbers.not(a);

        [MethodImpl(Inline)]
        public static num<T> operator ++(num<T> a)
            => Numbers.inc(a);

        [MethodImpl(Inline)]
        public static num<T> operator --(num<T> a)
            => Numbers.dec(a);

        [MethodImpl(Inline)]
        public static implicit operator T(num<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator num<T>(T src)
            => new num<T>(src);
    }
}