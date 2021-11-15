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
    using static minicore;

    public readonly struct Index<T> : IIndex<T>
    {
        readonly T[] Data;

        [MethodImpl(Inline)]
        public Index(T[] content)
            => Data = content;

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data?.Length ?? 0;
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public Span<T> Slice(uint offset)
            => slice(Edit, offset);

        [MethodImpl(Inline)]
        public Span<T> Slice(uint offset, uint length)
            => slice(Edit, offset, length);

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public ref T this[long i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data, i);
        }

        public ref T this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,i);
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public ref T Last
        {
            [MethodImpl(Inline)]
            get => ref Index.last(Data);
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => size<T>()*Count;
        }

        public Index<T> Sort()
        {
            if(Length != 0)
                Array.Sort(Data);
            return this;
        }

        [MethodImpl(Inline)]
        public bool Any(Func<T,bool> predicate)
        {
            var count = Count;
            var view = View;
            for(var i=0; i<count; i++)
                if(predicate(skip(view,i)))
                    return true;
            return false;
        }

        public Index<T> Clear()
        {
            if(Length !=0)
                Array.Clear(Data,0,Length);
            return this;
        }

        public bool Equals<C>(Index<T> src, C comparer)
            where C : IEqualityComparer<T>
                => Index.equals(View, src.View, comparer);
        public string Format()
            => string.Join(Chars.Comma, Data);

        public override string ToString()
            => Format();

        public Index<T> Reverse()
            => Index.reverse(Data);

        public Index<T> Sort<Y>(Y comparer = default)
            where Y : unmanaged, IComparer<T>
        {
            Array.Sort(Storage,comparer);
            return this;
        }

        [MethodImpl(Inline)]
        public bool Search(Func<T,bool> predicate, out T found)
            => Index.search(this, predicate, out found);

        public Index<Y> Cast<Y>()
            => new Index<Y>(Data.Select(x => cast<Y>(x)));

        public Index<Y> Select<Y>(Func<T,Y> selector)
             => Index.map(Data, selector);

        public Index<Z> SelectMany<Y,Z>(Func<T,Index<Y>> lift, Func<T,Y,Z> project)
             => Index.map(Data, lift, project);

        public Index<Y> SelectMany<Y>(Func<T,Index<Y>> lift)
             => Index.map(Data, lift);

        public Index<T> Where(Func<T,bool> predicate)
            => Index.filter(Data, predicate);

        public T Single()
            => Count == 1 ? this[0] : throw new Exception("More than one - or perhaps none");

        [MethodImpl(Inline)]
        public T[] ToArray()
            => Storage;

        [MethodImpl(Inline)]
        public Span<T> ToSpan()
            => Storage;

        /// <summary>
        /// Allocates and populates a copy of the underlying storage
        /// </summary>
        public Index<T> Replicate()
        {
            var dst = sys.alloc<T>(Count);
            Array.Copy(Storage,dst,Count);
            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator Span<T>(Index<T> src)
            => src.Edit;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(Index<T> src)
            => src.View;

        [MethodImpl(Inline)]
        public static implicit operator T[](Index<T> src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator Index<T>(T[] src)
            => new Index<T>(src);

        public static Index<T> Empty
        {
           [MethodImpl(Inline)]
           get => new Index<T>(sys.empty<T>());
        }
    }
}