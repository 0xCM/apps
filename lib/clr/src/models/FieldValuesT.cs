//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Covers a sequence of T-valued fields
    /// </summary>
    /// <typeparam name="T">The field value type</param>
    public readonly struct FieldValues<T> : IIndex<FieldValue<T>>
        where T : struct
    {
        readonly FieldValue<T>[] Data;

        [MethodImpl(Inline)]
        public FieldValues(FieldValue<T>[] src)
            => Data = src;

        public FieldValue<T>[] Storage
        {
            get => Data;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref readonly FieldValue<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly FieldValue<T> this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public Span<FieldValue<T>> ToSpan()
            => Data;

        [MethodImpl(Inline)]
        public static implicit operator FieldValues<T>(FieldValue<T>[] src)
            => new FieldValues<T>(src);


        [MethodImpl(Inline)]
        public static implicit operator FieldValue<T>[](FieldValues<T> src)
            => src.Data;
    }
}