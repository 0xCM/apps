//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct @string<K> : IString<K,string>, IComparable<@string<K>>, IEquatable<@string<K>>
        where K : unmanaged
    {
        readonly string Data;

        public K Kind {get;}

        [MethodImpl(Inline)]
        public @string(K kind, string src)
        {
            Kind = kind;
            Data = src;
        }

        public string Value
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Data);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Data);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Value.Length;
        }

        public string Format()
            => Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(@string<K> src)
            => bw64(Kind) == bw64(src.Kind) && Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(@string<K> src)
            => string.Format("{0}-{1}", bw64(Kind).ToString(), Value).CompareTo(string.Format("{0}-{1}", bw64(src.Kind), src.Value));

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object src)
            => src is @string<K> x && Equals(x);

        public static @string<K> Empty
        {
            [MethodImpl(Inline)]
            get => new @string<K>(default(K), EmptyString);
        }

        [MethodImpl(Inline)]
        public static implicit operator @string<K>((K kind, string content) src)
            => new @string<K>(src.kind, src.content);

        [MethodImpl(Inline)]
        public static implicit operator string(@string<K> src)
            => src.Value;

        public static bool operator ==(@string<K> a, @string<K> b)
            => a.Equals(b);

        public static bool operator !=(@string<K> a, @string<K> b)
            => !a.Equals(b);
    }
}