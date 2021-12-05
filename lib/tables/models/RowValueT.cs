//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct RowValue<T>
        where T : struct
    {
        T Source;

        [MethodImpl(Inline)]
        public RowValue(T data)
            => Source = data;

        public ReadOnlySpan<byte> View
        {
             [MethodImpl(Inline)]
             get => bytes(Source);
        }

        public Span<byte> Edit
        {
             [MethodImpl(Inline)]
             get => bytes(Source);
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Edit[(int)index];
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => size<T>();
        }

        [MethodImpl(Inline)]
        public static implicit operator RowValue<T>(T src)
            => new RowValue<T>(src);

        [MethodImpl(Inline)]
        public static explicit operator RowValue(RowValue<T> src)
            => new RowValue(src.Edit.ToArray());
    }
}