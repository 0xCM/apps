//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ItemList<T> : IIndex<ListItem<T>>
    {
        readonly Index<ListItem<T>> Data;

        [MethodImpl(Inline)]
        public ItemList(ListItem<T>[] src)
        {
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

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public string Format()
            => ListItems.format(this, Chars.Comma);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ItemList<T>(ListItem<T>[] src)
            => new ItemList<T>(src);

        public static ItemList<T> Empty => new ItemList<T>(sys.empty<ListItem<T>>());
    }
}