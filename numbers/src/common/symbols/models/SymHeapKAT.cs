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

        public readonly uint Size;

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => (uint)Entries.Length;
        }

        [MethodImpl(Inline)]
        public SymHeap(ReadOnlySpan<HeapEntry<K,O,L>> entries, ReadOnlySpan<char> data)
        {
            Entries = entries;
            Data = data;
            Size = (uint)(data.Length * 2);
        }

        [MethodImpl(Inline)]
        public K Key(uint index)
            => @as<K>(index);

        [MethodImpl(Inline)]
        public uint Index(K key)
            => bw32(key);

        [MethodImpl(Inline)]
        public ref readonly HeapEntry<K,O,L> Entry(uint index)
            => ref skip(Entries,index);

        [MethodImpl(Inline)]
        public ref readonly HeapEntry<K,O,L> Entry(K key)
            => ref skip(Entries, Index(key));

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(in HeapEntry<K,O,L> entry)
            => slice(Data,bw32(entry.Offset), bw32(entry.Length));

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(uint index)
            => Symbol(Entry(index));

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Symbol(K key)
            => Symbol(Entry(key));
    }
}