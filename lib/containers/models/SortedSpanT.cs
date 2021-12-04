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

    public readonly ref struct SortedSpan<T>
    {
        readonly Span<T> Data;

        internal SortedSpan(T[] src)
        {
            Data = src;
        }

        internal SortedSpan(Span<T> src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsEmpty;
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
        public static implicit operator ReadOnlySpan<T>(SortedSpan<T> src)
            => src.View;
    }
}