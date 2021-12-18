//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypedSeq<T> : ITypedSeq<T>
        where T : IEquatable<T>
    {
        readonly Index<T> Data;

        [MethodImpl(Inline)]
        public TypedSeq(T[] src)
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

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator TypedSeq<T>(T[] src)
            => new TypedSeq<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T[](TypedSeq<T> src)
            => src;

        public static TypedSeq<T> Empty => new TypedSeq<T>(sys.empty<T>());
    }
}