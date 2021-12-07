//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct num<T>
        where T : unmanaged
    {
        public T Value;

        [MethodImpl(Inline)]
        public num(T value)
            => Value = value;

        [MethodImpl(Inline)]
        public bool Equals(num<T> src)
            => num.eq(this, src);

        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value.ToString();

        public override bool Equals(object src)
            => src is num<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static bool operator ==(num<T> a, num<T> b)
            => num.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(num<T> a, num<T> b)
            => num.neq(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(num<T> a, num<T> b)
            => num.lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(num<T> a, num<T> b)
            => num.gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <=(num<T> a, num<T> b)
            => num.lteq(a,b);

        [MethodImpl(Inline)]
        public static bool operator >=(num<T> a, num<T> b)
            => num.gteq(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator +(num<T> a, num<T> b)
            => num.add(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator -(num<T> a, num<T> b)
            => num.sub(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator *(num<T> a, num<T> b)
            => num.mul(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator /(num<T> a, num<T> b)
            => num.div(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator %(num<T> a, num<T> b)
            => num.mod(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator -(num<T> a)
            => num.negate(a);

        [MethodImpl(Inline)]
        public static num<T> operator &(num<T> a, num<T> b)
            => num.and(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator |(num<T> a, num<T> b)
            => num.or(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator ^(num<T> a, num<T> b)
            => num.xor(a,b);

        [MethodImpl(Inline)]
        public static num<T> operator >>(num<T> a, int offset)
            => num.srl(a,(byte)offset);

        [MethodImpl(Inline)]
        public static num<T> operator <<(num<T> a, int offset)
            => num.sll(a,(byte)offset);

        [MethodImpl(Inline)]
        public static num<T> operator ~(num<T> a)
            => num.not(a);

        [MethodImpl(Inline)]
        public static implicit operator T(num<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator num<T>(T src)
            => new num<T>(src);
    }
}