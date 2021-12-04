//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public ref struct bvNx64
    {
        public const uint SegWidth = 64;

        readonly Span<ulong> Data;

        [MethodImpl(Inline)]
        public bvNx64(Span<ulong> data)
        {
            Data = data;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length;
        }

        [MethodImpl(Inline)]
        public bit ReadBit(uint i)
        {
            var offset = i % SegWidth;
            var pos = i % SegWidth;
            ref readonly var seg = ref Seg(offset);
            return bit.test(seg,(byte)pos);
        }

        [MethodImpl(Inline)]
        public void WriteBit(uint i, bit state)
        {
            var offset = i % SegWidth;
            var pos = i % SegWidth;
            ref var seg = ref Seg(offset);
            seg = bit.set(seg,(byte)pos, state);
        }

        public bit this[uint i]
        {
            [MethodImpl(Inline)]
            get => ReadBit(i);

            [MethodImpl(Inline)]
            set => WriteBit(i, value);
        }

        public ref bv64 Seg(W64 w, uint offset)
            => ref @as<ulong,bv64>(Seg(offset));

        [MethodImpl(Inline)]
        ref ulong Seg(uint offset)
            => ref seek(Data,offset);

        public BitWidth ContentWidth
        {
            [MethodImpl(Inline)]
            get => N*64;
        }

        public BitWidth StorageWidth
        {
            [MethodImpl(Inline)]
            get => N*64;
        }
    }

}