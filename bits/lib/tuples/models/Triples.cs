//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public readonly ref struct Triples<T>
    {
        readonly Span<Triple<T>> Data;

        [MethodImpl(Inline)]
        public Triples(Span<Triple<T>> src)
            => Data = src;

        [MethodImpl(Inline)]
        public ref Triple<T> Select(int index)
            => ref seek(Data, (uint)index);

        public ref Triple<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Select(index);
        }

        public int Count
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public IEnumerable<Triple<T>> Enumerate()
            => Data.ToEnumerable();

        [MethodImpl(Inline)]
        public static implicit operator Triples<T>(Span<Triple<T>> src)
            => new Triples<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Triples<T>(Triple<T>[] src)
            => new Triples<T>(src);
    }
}