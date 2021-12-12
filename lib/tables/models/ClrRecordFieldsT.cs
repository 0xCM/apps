//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ClrRecordFields<T> : IIndex<ClrRecordField<T>>
        where T : struct
    {
        readonly Index<ClrRecordField<T>> Data;

        [MethodImpl(Inline)]
        public ClrRecordFields(ClrRecordField<T>[] src)
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

        public ref ClrRecordField<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ClrRecordField<T> this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ReadOnlySpan<ClrRecordField<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<ClrRecordField<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ClrRecordField<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public static ClrRecordFields<T> Empty
            => new ClrRecordFields<T>(sys.empty<ClrRecordField<T>>());

        [MethodImpl(Inline)]
        public ClrRecordFields Refresh(ClrTableField[] src)
            => src;

        [MethodImpl(Inline)]
        public static implicit operator ClrRecordFields<T>(ClrRecordField<T>[] src)
            => new ClrRecordFields<T>(src);
    }
}