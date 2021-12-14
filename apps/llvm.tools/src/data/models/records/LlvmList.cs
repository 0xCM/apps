//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct LlvmList : IIndex<LlvmListItem>
    {
        readonly Index<LlvmListItem> Data;

        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public LlvmList(FS.FilePath path, LlvmListItem[] items)
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

        public LlvmListItem[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<LlvmListItem> Items
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Index<Identifier> Identifiers()
        {
            var items = Items;
            var count = items.Length;
            var dst = alloc<Identifier>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(items,i).Value;
            return dst;
        }

        public Index<string> Values()
        {
            var items = Items;
            var count = items.Length;
            var dst = alloc<string>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(items,i).Value;
            return dst;
        }

        public string Name
        {
            get => Path.FileName.WithoutExtension.Format().Remove("llvm.lists.");
        }

        public ItemList<string> ToItemList()
        {
            var src = Items;
            var count = src.Length;
            var dst = alloc<ListItem<string>>(count);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (i,skip(src,i).Value);
            return (Name, dst);
        }

        public NameList ToNameList()
        {
            return Named.list(Name, this.Map(x => x.Value));
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmList((FS.FilePath path, LlvmListItem[] items) src)
            => new LlvmList(src.path, src.items);

        public static LlvmList Empty => new LlvmList(FS.FilePath.Empty, sys.empty<LlvmListItem>());
    }
}