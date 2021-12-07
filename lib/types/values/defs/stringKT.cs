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

    public readonly struct @string<K,T> : IString<TypedSeq<T>>, IComparable<@string<K>>, IEquatable<@string<K>>
        where K : unmanaged
        where T : unmanaged, ITyped, IEquatable<T>
    {
        public TypedSeq<T> Content {get;}

        public K Kind {get;}

        [MethodImpl(Inline)]
        public @string(K kind, TypedSeq<T> src)
        {
            Kind = kind;
            Content = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public string Format()
        {
            var dst = text.buffer();
            var data = Content.View;
            var count = data.Length;
            for(var i=0; i<count; i++)
            {
                dst.Append(skip(data,0).Format());
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(@string<K> src)
            => bw64(Kind) == bw64(src.Kind) && Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public int CompareTo(@string<K> src)
            => string.Format("{0}-{1}", bw64(Kind).ToString(), Content).CompareTo(string.Format("{0}-{1}", bw64(src.Kind), src.Content));

        public override int GetHashCode()
            => Content.GetHashCode();

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