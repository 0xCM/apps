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

    public readonly struct @string<K,T> : IString<K,TypedSeq<T>>, IComparable<@string<K>>, IEquatable<@string<K>>
        where K : unmanaged
        where T : unmanaged, IEquatable<T>
    {
        public TypedSeq<T> Value {get;}

        public K Kind {get;}

        [MethodImpl(Inline)]
        public @string(K kind, TypedSeq<T> src)
        {
            Kind = kind;
            Value = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsNonEmpty;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Value.Length;
        }

        public string Format()
        {
            var dst = text.buffer();
            var data = Value.View;
            var count = data.Length;
            for(var i=0; i<count; i++)
            {
                dst.Append(skip(data,0).ToString());
            }
            return dst.Emit();
        }

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

        public static @string<K,T> Empty
        {
            [MethodImpl(Inline)]
            get => new @string<K,T>(default(K), TypedSeq<T>.Empty);
        }


        [MethodImpl(Inline)]
        public static implicit operator string(@string<K,T> src)
            => src.Format();

        // public static bool operator ==(@string<K> a, @string<K> b)
        //     => a.Equals(b);

        // public static bool operator !=(@string<K> a, @string<K> b)
        //     => !a.Equals(b);
    }
}