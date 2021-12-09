//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    public readonly struct LlvmList<K,V> : IIndex<LlvmListItem<K,V>>
    {
        readonly Index<LlvmListItem<K,V>> Data;

        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public LlvmList(FS.FilePath path, LlvmListItem<K,V>[] items)
        {
            Path = path;
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
            get => Path.FileName.WithoutExtension.Format();
        }

        public uint ItemCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public LlvmListItem<K,V>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<LlvmListItem<K,V>> Items
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmList<K,V>((FS.FilePath path, LlvmListItem<K,V>[] items) src)
            => new LlvmList<K,V>(src.path, src.items);

        public static LlvmList<K,V> Empty => new LlvmList<K,V>(FS.FilePath.Empty, sys.empty<LlvmListItem<K,V>>());
    }
}