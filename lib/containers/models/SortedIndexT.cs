//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SortedIndex<T> : ISortedIndex<T>
        where T : IComparable<T>
    {
        public static SortedIndex<T> sort(T[] src)
            => new SortedIndex<T>(src);

        readonly Index<T> Data;

        internal SortedIndex(T[] src)
        {
            Array.Sort(src);
            Data = src;
        }

        public T[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly T this[long index]
        {
             [MethodImpl(Inline)]
             get => ref Data[index];
        }

        public ref readonly T this[ulong index]
        {
             [MethodImpl(Inline)]
             get => ref Data[index];
        }

        /// <summary>
        /// The number of collected functions
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public static SortedIndex<T> Empty
            => new SortedIndex<T>(sys.empty<T>());
    }
}