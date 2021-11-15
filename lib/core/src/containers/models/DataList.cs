//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Collections;

    using static Root;
    using static core;

    public readonly struct DataList
    {
        public static DataList<T> create<T>(uint capacity = 128)
            => new DataList<T>(capacity);

        public static DataList<T> create<T>(uint? capacity)
            => new DataList<T>(capacity ?? 128);
    }

    public class DataList<T> : IEnumerable<T>
    {
        readonly List<T> Elements;

        bool Closed;

        public DataList()
        {
            Elements = new List<T>(128);
            Closed = false;
        }

        public DataList(uint capacity)
        {
            Elements = new List<T>((int)capacity);
            Closed = false;
        }

        public DataList(T[] src)
        {
            Elements = new List<T>(src.Length);
            Elements.AddRange(src);
        }

        [MethodImpl(Inline)]
        public void Add(T src)
        {
            if(!Closed)
                Elements.Add(src);
        }

        [MethodImpl(Inline)]
        public void Add(ReadOnlySpan<T> src)
        {
            if(!Closed)
                iter(src,Add);
        }

        [MethodImpl(Inline)]
        public void Add(T[] src)
        {
            if(!Closed)
                Elements.AddRange(src);
        }

        [MethodImpl(Inline)]
        public void Add(Index<T> src)
        {
            if(!Closed)
                Elements.AddRange(src.Storage);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Elements.Count;
        }

        public Span<T> Close()
        {
            var storage = Elements.EditDeposited();
            Closed = true;
            return storage;
        }

        public ReadOnlySpan<T> View()
            => Elements.ViewDeposited();

        [MethodImpl(Inline)]
        public Index<T> Emit(bool clear = true)
        {
            var data = Elements.ToArray();
            Clear();
            return data;
        }

        [MethodImpl(Inline)]
        public void Clear()
        {
            Elements.Clear();
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Elements.Count != 0;
        }

        public T this[int index]
        {
            [MethodImpl(Inline)]
            get => Elements[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Elements.Count == 0;
        }

        public IReadOnlyList<T> Items
        {
            [MethodImpl(Inline)]
            get => Elements;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Elements).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => ((IEnumerable<T>)Elements).GetEnumerator();


        [MethodImpl(Inline)]
        public static implicit operator DataList<T>(T[] src)
            => new DataList<T>(src);

        public static DataList<T> Empty
        {
            [MethodImpl(Inline)]
            get => sys.empty<T>();
        }
    }
}