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

    [ApiComplete]
    public ref struct SpanWriter
    {
        readonly Span<byte> Data;

        uint Position;

        public Span<byte> Target
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint BytesWritten
        {
            [MethodImpl(Inline)]
            get => Position;
        }

        [MethodImpl(Inline)]
        public SpanWriter(Span<byte> src)
        {
            Data = src;
            Position = 0;
        }

        [MethodImpl(Inline)]
        public byte Write8(byte src)
        {
            seek(Data, Position++) = src;
            return 1;
        }

        [MethodImpl(Inline)]
        public byte Write16(ushort src)
        {
            cell16(Data, Position += 2) = src;
            return 2;
        }

        [MethodImpl(Inline)]
        public byte Write16(byte lo, byte hi)
        {
            seek(Data, Position++) = lo;
            seek(Data, Position++) = hi;
            return 2;
        }

        [MethodImpl(Inline)]
        public byte Write32(uint src)
        {
            cell32(Data, Position += 4) = src;
            return 4;
        }

        [MethodImpl(Inline)]
        public byte Write64(ulong src)
        {
            cell64(Data, Position += 8) = src;
            return 8;
        }

        [MethodImpl(Inline)]
        public ByteSize Write<T>(in T src)
            where T : unmanaged
        {
            cell<T>(Data, Position += size<T>()) = src;
            return size<T>();
        }
    }
}