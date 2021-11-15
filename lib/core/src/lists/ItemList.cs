//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ItemList : IIndex<ListItem>
    {
        readonly Index<ListItem> Data;

        [MethodImpl(Inline)]
        public ItemList(ListItem[] src)
        {
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

        public static ItemList Empty => new ItemList(sys.empty<ListItem>());
    }
}