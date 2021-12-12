//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LocatedItems<T> : IItemList<ListItem<T>>, ILocated<FS.FilePath>
    {
        readonly Index<ListItem<T>> Data;

        public FS.FilePath Location {get;}

        [MethodImpl(Inline)]
        public LocatedItems(FS.FilePath loc, ListItem<T>[] src)
        {
            Location = loc;
            Data = src;
        }

        public ref ListItem<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref ListItem<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public Span<ListItem<T>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<ListItem<T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ListItem<T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public string ListId
        {
            [MethodImpl(Inline)]
            get => Location.FileName.WithoutExtension.Format();
        }

        public ItemList<T> List
        {
            [MethodImpl(Inline)]
            get => Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public static implicit operator ItemList<T>(LocatedItems<T> src)
            => src.List;
        public string Format()
            => ItemLists.format(List);


        public override string ToString()
            => Format();

        public static LocatedItems<T> Empty => new LocatedItems<T>(FS.FilePath.Empty, sys.empty<ListItem<T>>());
    }
}