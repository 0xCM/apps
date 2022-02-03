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

        public ByteSize BytesWritten
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
        public byte Write1(byte src)
        {
            seek(Data, Position++) = src;
            return 1;
        }

        [MethodImpl(Inline)]
        public byte Write2(ushort src)
        {
            cell16(Data, Position += 2) = src;
            return 2;
        }

        [MethodImpl(Inline)]
        public byte Write2(byte lo, byte hi)
        {
            seek(Data, Position++) = lo;
            seek(Data, Position++) = hi;
            return 2;
        }

        [MethodImpl(Inline)]
        public byte Write4(uint src)
        {
            cell32(Data, Position += 4) = src;
            return 4;
        }

        [MethodImpl(Inline)]
        public byte Write8(ulong src)
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

        [MethodImpl(Inline)]
        public byte Write<T>(N1 n, in T src)
            where T : unmanaged
        {
            seek(Data, Position += n) = u8(src);
            return n;
        }

        [MethodImpl(Inline)]
        public byte Write<T>(N2 n, in T src)
            where T : unmanaged
        {
            @as<ushort>(seek(Data, Position += n)) = u16(src);
            return n;
        }

        [MethodImpl(Inline)]
        public byte Write<T>(N3 n, in T src)
            where T : unmanaged
        {
            @as<ushort>(seek(Data, Position += 2)) = u16(src);
            seek(Data, Position += 1) = skip(bytes(src),2);
            return 3;
        }

        [MethodImpl(Inline)]
        public byte Write<T>(N4 n, in T src)
            where T : unmanaged
        {
            @as<uint>(seek(Data, Position += n)) = u32(src);
            return n;
        }

        [MethodImpl(Inline)]
        public byte Write<T>(N8 n, in T src)
            where T : unmanaged
        {
            @as<ulong>(seek(Data, Position += n)) = u64(src);
            return n;
        }
    }
}