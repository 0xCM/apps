//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Hex<K> : IHexNumber<K>, IEquatable<Hex<K>>, IComparable<Hex<K>>
        where K : unmanaged, IHexNumber<K>, IEquatable<K>, IComparable<K>, ITextual
    {
        public K Value {get;}

        [MethodImpl(Inline)]
        public Hex(K value)
        {
            Value = value;
        }

        public bool IsZero
        {
             [MethodImpl(Inline)]
             get => Value.IsZero;
        }

        public bool IsNonZero
        {
             [MethodImpl(Inline)]
             get => Value.IsNonZero;
        }

        public uint Hash
        {
             [MethodImpl(Inline)]
             get => Value.Hash;
        }

        public bool Equals(Hex<K> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(Hex<K> src)
            => Value.CompareTo(src.Value);

        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is Hex<K> h && Equals(h);

        [MethodImpl(Inline)]
        public static implicit operator Hex<K>(K src)
            => new Hex<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator K(Hex<K> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static bool operator==(Hex<K> x, Hex<K> y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator!=(Hex<K> x, Hex<K> y)
            => !x.Equals(y);
    }
}