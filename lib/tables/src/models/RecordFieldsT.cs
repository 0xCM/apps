//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RecordFields<T> : IIndex<RecordField<T>>
        where T : struct
    {
        readonly Index<RecordField<T>> Data;

        [MethodImpl(Inline)]
        public RecordFields(RecordField<T>[] src)
            => Data = src;

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

        public ref RecordField<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref RecordField<T> this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<RecordField<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<RecordField<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public RecordField<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public static RecordFields<T> Empty
            => new RecordFields<T>(sys.empty<RecordField<T>>());

        [MethodImpl(Inline)]
        public RecordFields Refresh(RecordField[] src)
            => src;

        [MethodImpl(Inline)]
        public static implicit operator RecordFields<T>(RecordField<T>[] src)
            => new RecordFields<T>(src);
    }
}