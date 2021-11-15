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

    public readonly ref struct BlockedBits<T>
        where T : unmanaged
    {
        public readonly uint BitCount {get;}

        public readonly uint CellWidth {get;}

        public readonly uint CellCount {get;}

        public readonly uint BlockCount {get;}

        readonly SpanBlock64<T> Data;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public BlockedBits(SpanBlock64<T> src, uint bitcount)
        {
            Data = src;
            BitCount = bitcount;
            CellWidth = width<T>(w8);
            BlockCount = (uint)src.BlockCount;
            CellCount = (uint)src.CellCount;
        }

        [MethodImpl(Inline)]
        public T Slice(byte start, byte length)
            => gbits.slice(Data[(int)(start/CellWidth)], (byte)(start % CellWidth), length);

        public bit this[ByteSize offset, byte pos]
        {
            [MethodImpl(Inline)]
            get => bit.test(Bytes[offset], pos);

            [MethodImpl(Inline)]
            set => Bytes[offset] = bit.set(Bytes[offset], pos, value);
        }
    }
}