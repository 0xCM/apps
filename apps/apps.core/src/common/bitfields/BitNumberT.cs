//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BitNumber<T> : IBitNumber<BitNumber<T>,T>, IEquatable<T>, IComparable<T>
        where T : unmanaged
    {
        public readonly T Value;

        public readonly byte Width;

        public void Bits<B>(B dst)
            where B : unmanaged, IStorageBlock<B>
                => BitNumber.unpack(this,dst);

        byte IBits.Width
            => Width;

        [MethodImpl(Inline)]
        public BitNumber(byte n, T src)
        {
            Width = n;
            Value = src;
        }

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

        T IBits<T>.Value
            => Value;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => alg.ghash.calc(Value);
        }

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
        public bool Equals(T src)
            => gmath.eq(Value,src);

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => i32(Value);

        [MethodImpl(Inline)]
        public override bool Equals(object src)
            => (src is BitNumber<T> bn && src.Equals(bn)) || (src is T t && Equals(t));

        [MethodImpl(Inline)]
        public static implicit operator T (BitNumber<T> src)
            => src.Value;


    }
}