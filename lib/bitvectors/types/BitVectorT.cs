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

    public struct BitVector<T>
        where T : unmanaged
    {
        T State;

        [MethodImpl(Inline)]
        public BitVector(in T state)
        {
            State = state;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(State);
        }

        [MethodImpl(Inline)]
        Span<byte> Segment(uint offset)
            => slice(Bytes, offset);

        [MethodImpl(Inline)]
        public ref ScalarBits<byte> Scalar(W8 w, uint offset)
            => ref first(recover<ScalarBits<byte>>(Segment(offset)));

        [MethodImpl(Inline)]
        public ref ScalarBits<ushort> Scalar(W16 w, uint offset)
            => ref first(recover<ScalarBits<ushort>>(Segment(offset)));

        [MethodImpl(Inline)]
        public ref ScalarBits<uint> Scalar(W32 w, uint offset)
            => ref first(recover<ScalarBits<uint>>(Segment(offset)));

        [MethodImpl(Inline)]
        public ref ScalarBits<ulong> Scalar(W64 w, uint offset)
            => ref first(recover<ScalarBits<ulong>>(Segment(offset)));
    }
}