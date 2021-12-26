//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType(TypeSyntax.Seq)]
    public readonly struct Seq<T> : ISeq<T>
        where T : IEquatable<T>
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public Seq(T[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ReadOnlySpan<T> Elements
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly T this[long i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref readonly T Last
        {
            [MethodImpl(Inline)]
            get => ref Data.Last;
        }

        public string Format()
            => string.Join(Chars.Comma, Data.Storage);

        public override string ToString()
            => Format();

        public Seq<T> Reverse()
            => new Seq<T>(Data.Reverse());

        [MethodImpl(Inline)]
        public T[] ToArray()
            => Data;

        [MethodImpl(Inline)]
        public static implicit operator Seq<T>(T[] src)
            => new Seq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](Seq<T> src)
            => src.Data.Storage;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(Seq<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Seq<T>(Index<T> src)
            => new Seq<T>(src.Storage);

        public static Seq<T> Empty => new Seq<T>(sys.empty<T>());
    }
}