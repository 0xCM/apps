//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ItemList : IItemList<ListItem>
    {
        readonly Index<ListItem> Data;

        public readonly string Name;

        [MethodImpl(Inline)]
        public ItemList(ListItem[] src)
        {
            Name = EmptyString;
            Data = src;
        }

        [MethodImpl(Inline)]
        public ItemList(string name, ListItem[] src)
        {
            Name = name;
            Data = src;
        }

        public ref ListItem this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListItem this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public Span<ListItem> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<ListItem> View
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ListItem[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator ItemList(ListItem[] src)
            => new ItemList(src);

        [MethodImpl(Inline)]
        public static implicit operator ItemList((string name, ListItem[] items) src)
            => new ItemList(src.name, src.items);

        public static ItemList Empty => new ItemList(sys.empty<ListItem>());
    }
}