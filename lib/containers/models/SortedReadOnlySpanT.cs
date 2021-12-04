//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static minicore;

    public readonly ref struct SortedReadOnlySpan<T>
    {
        readonly ReadOnlySpan<T> Data;

        public SortedReadOnlySpan(SortedSpan<T> src)
        {
            Data = src;
        }

        internal SortedReadOnlySpan(ReadOnlySpan<T> src)
        {
            Data = src;
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref readonly T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref skip(Data,index);
        }

        public ref readonly T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref skip(Data,index);
        }

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<T>(SortedReadOnlySpan<T> src)
            => src.View;

        [MethodImpl(Inline)]
        public static implicit operator SortedReadOnlySpan<T>(SortedSpan<T> src)
            => new SortedReadOnlySpan<T>(src);
    }
}