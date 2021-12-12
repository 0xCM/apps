//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LocatedItems<K,V> : IItemList<ListItem<K,V>>, ILocated<FS.FilePath>
        where K : unmanaged
    {
        readonly Index<ListItem<K,V>> Data;

        public FS.FilePath Location {get;}

        [MethodImpl(Inline)]
        public LocatedItems(FS.FilePath path, ListItem<K,V>[] items)
        {
            Location = path;
            Data = items;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public string ListId
        {
            [MethodImpl(Inline)]
            get => Location.FileName.WithoutExtension.Format();
        }

        public ItemList<K,V> List
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        public uint ItemCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ListItem<K,V>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<ListItem<K,V>> Items
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => ItemLists.format(List);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LocatedItems<K,V>((FS.FilePath path, ListItem<K,V>[] items) src)
            => new LocatedItems<K,V>(src.path, src.items);

        public static LocatedItems<K,V> Empty => new LocatedItems<K,V>(FS.FilePath.Empty, sys.empty<ListItem<K,V>>());
    }
}