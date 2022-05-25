//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = MemoryStrings;

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

        public MemoryAddress CharBase
        {
            [MethodImpl(Inline)]
            get => Data.CharBase;
        }

        public MemoryAddress OffsetBase
        {
            [MethodImpl(Inline)]
            get => Data.OffsetBase;
        }

        public ReadOnlySpan<char> Cells(K index)
            => api.chars(Data, bw32(index));

        public ReadOnlySpan<char> Cells(uint index)
            => api.chars(Data, index);

        public ReadOnlySpan<char> Cells(int index)
            => api.chars(Data, index);

        public MemoryString<K> this[K index]
        {
            [MethodImpl(Inline)]
            get => api.@string(this, index);
        }

        public MemoryString<K> this[int index]
        {
            [MethodImpl(Inline)]
            get => api.@string(this, (uint)index);
        }

        public MemoryString<K> this[uint index]
        {
            [MethodImpl(Inline)]
            get => api.@string(this, index);
        }

        public unsafe ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => api.offsets(Data);
        }

        [MethodImpl(Inline)]
        public static implicit operator MemoryStrings<K>(MemoryStrings src)
            => new MemoryStrings<K>(src);
    }
}