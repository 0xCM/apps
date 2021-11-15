//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct RowValue
    {
        BinaryCode Data;

        [MethodImpl(Inline)]
        public static implicit operator RowValue(byte[] src)
            => new RowValue(src);

        [MethodImpl(Inline)]
        public static implicit operator RowValue(BinaryCode src)
            => new RowValue(src);

        [MethodImpl(Inline)]
        public RowValue(BinaryCode data)
            => Data = data;

        [MethodImpl(Inline)]
        public RowValue(byte[] data)
            => Data = data;

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref byte this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }
    }
}