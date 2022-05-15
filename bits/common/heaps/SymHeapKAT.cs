//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public ref struct SymHeap<K,A,T>
        where K : unmanaged
        where A : unmanaged
        where T : unmanaged
    {
        readonly ReadOnlySpan<SymHeapEntry<K,A,T>> Entries;

        readonly ReadOnlySpan<char> Data;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Entries.Length;
        }

        [MethodImpl(Inline)]
        public SymHeap(ReadOnlySpan<SymHeapEntry<K,A,T>> entries, ReadOnlySpan<char> data)
        {
            Entries = entries;
            Data = data;
        }

        [MethodImpl(Inline)]
        public ref readonly SymHeapEntry<K,A,T> Entry(uint index)
            => ref skip(Entries,index);

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(in SymHeapEntry<K,A,T> entry)
            => slice(Data,bw32(entry.Offset),bw32(entry.Length));

        public ReadOnlySpan<char> this[K key]
        {
            [MethodImpl(Inline)]
            get => Symbol(Entry(bw32(key)));
        }
    }
}