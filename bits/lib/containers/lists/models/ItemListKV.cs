//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ItemList<K,T> : IItemList<ListItem<K,T>>
    {
        readonly Index<ListItem<K,T>> Data;

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public ItemList(ListItem<K,T>[] src)
        {
            Data = src;
            Name = EmptyString;
        }

        [MethodImpl(Inline)]
        public ItemList(Identifier name, ListItem<K,T>[] src)
        {
            Name = name;
            Data = src;
        }

        public ref ListItem<K,T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListItem<K,T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public Span<ListItem<K,T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<ListItem<K,T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ListItem<K,T>[] Storage
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

        public string Format()
            => ItemLists.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ItemList<K,T>(ListItem<K,T>[] src)
            => new ItemList<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator ItemList<K,T>((string name, ListItem<K,T>[] items) src)
            => new ItemList<K,T>(src.name, src.items);

        [MethodImpl(Inline)]
        public static implicit operator ListItem<K,T>[](ItemList<K,T> src)
            => src.Storage;

        public static ItemList<T> Empty => new ItemList<T>(sys.empty<ListItem<T>>());
    }
}