//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct ListItem<K,V> : IListItem<K,V>
        where K : unmanaged
    {
        public K Key {get;}

        public V Value {get;}

        [MethodImpl(Inline)]
        public ListItem(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public string Format()
            => string.Format(ListItem.RenderPattern, Key, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ListItem<K,V>((K key, V content) src)
            => new ListItem<K,V>(src.key, src.content);
    }
}