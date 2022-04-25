//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitNumber<N,T> : IBitNumber<BitNumber<N,T>,T>, IEquatable<T>, IEquatable<BitNumber<T>>, IComparable<BitNumber<T>>, IComparable<T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public BitNumber(T src)
        {
            Value = src;
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => nat8u<N>();
        }

        T IBits<T>.Value
            => Value;

        public void Bits<B>(B dst)
            where B : unmanaged, IStorageBlock<B>
                => BitNumber.unpack(this,dst);

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => !gmath.nonz(Value);
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => gmath.nonz(Value);
        }


        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Value);
        }

        public int CompareTo(BitNumber<N,T> src)
            => gmath.cmp(Value, src.Value);

        public int CompareTo(BitNumber<T> src)
            => gmath.cmp(Value, src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(T src)
            => gmath.cmp(Value, src);

        public string Format()
            => BitNumber.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(BitNumber<T> src)
            => gmath.eq(Value, src.Value);

        [MethodImpl(Inline)]
        public bool Equals(BitNumber<N,T> src)
            => gmath.eq(Value, src.Value);

        [MethodImpl(Inline)]
        public bool Equals(T src)
            => gmath.eq(Value,src);

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => i32(Value);

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => (src is BitNumber<T> bn && src.Equals(bn)) || (src is T t && Equals(t) || src is BitNumber<N,T> n && Equals(n));

        [MethodImpl(Inline)]
        public static implicit operator BitNumber<T>(BitNumber<N,T> src)
            => new BitNumber<T>(src.Width, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator T(BitNumber<N,T> src)
            => src.Value;
    }
}