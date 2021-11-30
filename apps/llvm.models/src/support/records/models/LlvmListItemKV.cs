//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct LlvmListItem<K,V>
    {
        public const string TableId = "llvm.lists";

        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public LlvmListItem(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public string Format()
            => string.Format("{0,-8} | {1}", Key, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LlvmListItem<K,V>((K key, V content) src)
            => new LlvmListItem<K,V>(src.key, src.content);
    }
}