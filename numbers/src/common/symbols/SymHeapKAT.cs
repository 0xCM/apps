//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Covers a contiguous <see cref='char'/> sequence
    /// </summary>
    /// <typeparam name="K">The linear index type</typeparam>
    /// <typeparam name="O">The offset type</typeparam>
    /// <typeparam name="L">The length type</typeparam>
    public ref struct SymHeap<K,O,L>
        where K : unmanaged
        where O : unmanaged
        where L : unmanaged
    {
        readonly ReadOnlySpan<HeapEntry<K,O,L>> Entries;

        readonly ReadOnlySpan<char> Data;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Entries.Length;
        }

        [MethodImpl(Inline)]
        public SymHeap(ReadOnlySpan<HeapEntry<K,O,L>> entries, ReadOnlySpan<char> data)
        {
            Entries = entries;
            Data = data;
        }

        [MethodImpl(Inline)]
        public ref readonly HeapEntry<K,O,L> Entry(uint index)
            => ref skip(Entries,index);

        public ReadOnlySpan<char> this[K key]
        {
            [MethodImpl(Inline)]
            get => Symbol(Entry(bw32(key)));
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(in HeapEntry<K,O,L> entry)
            => slice(Data,bw32(entry.Offset),bw32(entry.Length));
    }
}