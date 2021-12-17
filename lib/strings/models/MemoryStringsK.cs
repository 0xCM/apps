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

    using api = strings;

    public readonly struct MemoryStrings<K>
        where K : unmanaged
    {
        readonly MemoryStrings Data;

        [MethodImpl(Inline)]
        public MemoryStrings(in MemoryStrings data)
        {
            Data = data;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Data.EntryCount;
        }

        public uint CharCount
        {
            [MethodImpl(Inline)]
            get => Data.CharCount;
        }

        public MemoryAddress OffsetBase
        {
            [MethodImpl(Inline)]
            get => Data.OffsetBase;
        }

        public MemoryAddress CharBase
        {
            [MethodImpl(Inline)]
            get => Data.CharBase;
        }

        public ReadOnlySpan<char> this[K index]
        {
            [MethodImpl(Inline)]
            get => api.chars(Data, bw32(index));
        }

        [MethodImpl(Inline)]
        public ref readonly uint Offset(K index)
            => ref skip(Offsets, bw32(index));

        public unsafe ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => api.offsets(Data);
        }
    }
}