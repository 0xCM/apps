//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    [Free]
    public abstract class ReadOnlySeq<S,T> : IReadOnlySeq<T>
        where S : ReadOnlySeq<S,T>
    {
        protected readonly Index<T> Data;

        [MethodImpl(Inline)]
        protected ReadOnlySeq(T[] src)
        {
            Data =src;
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

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ref readonly T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<T>.Enumerator GetEnumerator()
            => View.GetEnumerator();
    }
}