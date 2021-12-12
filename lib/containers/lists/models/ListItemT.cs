//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ListItem<T> : IListItem<T>
    {
        public uint Key {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public ListItem(uint index, T content)
        {
            Key = index;
            Value = content;
        }

        public string Format()
            => string.Format(ListItem.RenderPattern, Key, Value);

        public override string ToString()
            => Format();

        public ListItem Untype()
            => ItemLists.untype(this);

        [MethodImpl(Inline)]
        public static implicit operator ListItem<T>((uint index, T content) src)
            => new ListItem<T>(src.index, src.content);
    }
}