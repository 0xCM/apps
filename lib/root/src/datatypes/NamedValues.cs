//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NamedValues
    {
        [MethodImpl(Inline)]
        public static NamedValue<K,T> define<K,T>(in K name, in T value)
            => new NamedValue<K,T>(name,value);

        [MethodImpl(Inline)]
        public static NamedValues<V> empty<V>()
            => new NamedValues<V>();
    }

    public readonly struct NamedValues<T>
    {
        public NamedValue<T>[] Data {get;}

        [MethodImpl(Inline)]
        public NamedValues(params NamedValue<T>[] src)
            => Data = src;

        public Count Count
        {
            [MethodImpl(Inline)]
            get => Data?.Length ?? 0;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data?.Length ?? 0;
        }

        public NamedValue<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<NamedValue<T>> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<NamedValue<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
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

        [MethodImpl(Inline)]
        public static implicit operator NamedValues<T>(NamedValue<T>[] src)
            => new NamedValues<T>(src);
    }
}