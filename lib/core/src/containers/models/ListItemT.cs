//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ListItem<T>
    {
        public readonly uint Id;

        public readonly T Content;

        [MethodImpl(Inline)]
        public ListItem(uint index, T content)
        {
            Id = index;
            Content = content;
        }

        public string Format()
            => string.Format("{0:D6}:{1}", Id, Content);

        public override string ToString()
            => Format();

        public ListItem ToRecord(string type)
            => ListItems.record(this, type);

        [MethodImpl(Inline)]
        public static implicit operator ListItem<T>((uint index, T content) src)
            => new ListItem<T>(src.index, src.content);
    }
}