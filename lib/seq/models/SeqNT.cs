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

    [DataType(TypeSyntax.SeqN)]
    public readonly struct Seq<N,T> : ISeq<N,T>
        where T : IEquatable<T>
        where N : unmanaged, ITypeNat
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        internal Seq(T[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => nat32u<N>();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Count != 0;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => nat32i<N>();
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

        public Seq<N,T> Reverse()
            => new Seq<N,T>(Data.Reverse());

        [MethodImpl(Inline)]
        public T[] ToArray()
            => Data;

        [MethodImpl(Inline)]
        public static implicit operator T[](Seq<N,T> src)
            => src.Data.Storage;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(Seq<N,T> src)
            => src.Data;

        public static Seq<N,T> Empty => new Seq<N,T>(sys.empty<T>());
    }
}